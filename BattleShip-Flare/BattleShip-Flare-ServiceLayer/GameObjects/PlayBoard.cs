
using BattleShip_Game_ServiceLayer.Enums;
using BattleShip_Game_ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;

namespace BattleShip_Game_ServiceLayer.Services
{
    public class PlayBoard
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public List<Square> Squares { get; set; }
        
        int maxRows = 10, maxColumns = 10;
        public PlayBoard()
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
        public PlayBoard AssingPlayBoard()
        {
            return this;
        }
    }
}


