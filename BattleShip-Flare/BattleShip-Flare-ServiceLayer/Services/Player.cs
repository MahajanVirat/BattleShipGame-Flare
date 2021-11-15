
using BattleShip_Game_ServiceLayer.Enums;
using BattleShip_Game_ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleShip_Game_ServiceLayer.Services
{
    /// <summary>
    /// This class would instantiate new players along with their boards, ships and also randomly places Ships on the Board.
    /// </summary>
    public class Player : IPlayer
    {
        public Player(string _Name)
        {
            PlayerName = _Name;
            PlayBoard = new PlayBoard();
            Ships = new List<Ship>() {
                new CarrierShip("CarrierShip",4),
                new DestroyerShip("DestroyerShip",2)
            };
            SetupShipsOnBoard();
            ShowBoards();
        }

        public string PlayerName { get; set; }
        public PlayBoard PlayBoard { get; set; }
        public List<Ship> Ships { get; set; }
      
        // This Method will Randomly places ships on the Board either Vertically(endRow = Shipsize)  or Horizontaly(endCol = Shipsize) 
        //Ships should not intersect each other
        //Ship size should not exceed 1 X N where N <= 10 and should not lie outside the Board
        //Check squares should not be occupied - before placing the ship
        //Choose a Random Orientation of Ship and choose a random squares to place the ship based on the ship size
        private void SetupShipsOnBoard()
        {
            Random random = new Random();
            foreach (Ship ship in Ships)
            {
                bool shipPlaced = false;

                while (!shipPlaced)
                {
                    int startRow = random.Next(1, PlayBoard.Height + 1);
                    int startColumn = random.Next(1, PlayBoard.Width + 1);
                    int endRow = startRow;
                    int endColumn = startColumn;

                    int shipOrientation = random.Next(1, PlayBoard.Squares.Count + 1) % 2; //Vertical or Horizontal

                    if (shipOrientation == 0) //Place the ship Vertical
                    {
                        endRow = endRow + ship.ShipSize - 1;
                    }
                    else ////Place the ship Horizontal
                    {
                        endColumn = endColumn + ship.ShipSize - 1;
                    }
                    //Ships cannot be placed outside the Board
                    if (endColumn > 10 || endRow > 10)
                    {
                        shipPlaced = false;
                        continue;
                    }

                    List<Square> squareRanges = new List<Square>();

                    squareRanges = PlayBoard.Squares.Where(x => x.Coordinates.Row >= startRow
                    && x.Coordinates.Row <= endRow && x.Coordinates.Column >= startColumn && x.Coordinates.Column <= endColumn).ToList();

                    if (squareRanges.Any(x => x.Istaken()))
                    {
                        shipPlaced = false;
                        continue;
                    }
                    foreach (Square square in squareRanges)
                    {
                        square.SquareType = (SquareType)ship.ShipType;
                    }
                    shipPlaced = true;
                }
            }
        }
        public Result SpotShot(Coordinates coordinates)
        {
            Square square = PlayBoard.Squares.First(x => x.Coordinates.Row == coordinates.Row && x.Coordinates.Column == coordinates.Column);

            if (!square.Istaken())
            {
                Console.WriteLine(PlayerName + " says: It's a Miss");
                if (square.SquareType != SquareType.HIT)
                    square.SquareType = SquareType.MISS;

                return Result.MISS;
            }

            Ship ship = Ships.First(x => (SquareType)x.ShipType == square.SquareType);

            square.SquareType = SquareType.HIT;

            ship.Hits++;

            Console.WriteLine(PlayerName + " says: It's a Hit");

            if (ship.IsSunk())
            {
                Console.WriteLine(" and you sunk my " + ship.Name + " !");
            }
            return Result.HIT;
        }
        public void ShowBoards()
        {
            Console.WriteLine(PlayerName + "'s Board:");
            for (int i = 1; i <= PlayBoard.Height; i++)
            {
                for (int j = 1; j <= PlayBoard.Width; j++)
                {
                    Console.Write(PlayBoard.Squares.Where(x => x.Coordinates.Row == i && x.Coordinates.Column == j).First().Status + "   ");
                }
                Console.WriteLine(Environment.NewLine);
            }
        }
        public bool HasLost => Ships.All(x => x.IsSunk());
    }
}
