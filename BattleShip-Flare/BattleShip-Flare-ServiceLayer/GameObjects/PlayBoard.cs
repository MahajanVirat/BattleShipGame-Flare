using System.Collections.Generic;

namespace BattleShip_Game_ServiceLayer.Services
{
    public class PlayBoard
    {
        public int Height { get; set; }

        public int Width { get; set; }

        public List<Square> Squares { get; set; }

        public PlayBoard(int maxRows, int maxColumns)
        {
            Squares = new List<Square>();
            Height = maxRows; Width = maxColumns;
            for (int i = 1; i <= maxRows; i++)
            {
                for (int j = 1; j <= maxColumns; j++)
                {
                    Squares.Add(new Square(i, j));
                }
            }
        }
    }
}


