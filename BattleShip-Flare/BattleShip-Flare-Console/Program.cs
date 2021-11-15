using BattleShip_Game_ServiceLayer.Interfaces;
using BattleShip_Game_ServiceLayer.Services;
using System;

namespace BattleShip_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            IPlayer player1 = new Player("Virat");
            IPlayer player2 = new Player("Reza");

            IGamePlay gamePlay = new GamePlay
            {
                Player1 = player1,
                Player2 = player2,
                PlayerInAction = player1
            };

            while (!gamePlay.PlayerInAction.HasLost)
            {
                Console.WriteLine(gamePlay.PlayerInAction.PlayerName + "'s Turn ");
                Console.WriteLine("Enter Row: "); string row = Console.ReadLine();
                Console.WriteLine("Enter Column: "); string column = Console.ReadLine();

                Console.WriteLine(gamePlay.PlayerInAction.PlayerName + " says: Coordinates are " + row + ", " + column);

                gamePlay.PlayTurn(Convert.ToInt32(row), Convert.ToInt32(column), gamePlay.PlayerInAction);

                if (gamePlay.PlayerInAction == player1)
                {
                    gamePlay.PlayerInAction = player2;
                }
                else
                {
                    gamePlay.PlayerInAction = player1;
                }
                if (gamePlay.PlayerInAction.HasLost)
                {
                    Console.WriteLine(gamePlay.PlayerInAction.PlayerName + " has lost the Game");
                }
            }
            Console.ReadLine();
        }
    }
}
