using BattleShip_Game_ServiceLayer.Enums;

namespace BattleShip_Game_ServiceLayer
{
    public class Square
    {
        public Square(int i, int j)
        {
            Coordinates = new Coordinates(i, j);
            SquareType = SquareType.Empty;
        }

        public bool Istaken()
        {
            return SquareType == SquareType.Carrier
                || SquareType == SquareType.Destroyer;           
        }

        public Coordinates Coordinates { get; set; }
        public SquareType SquareType { get; set; }

        public string Status
        {
            get
            {
                return ((char)SquareType).ToString();
            }
        }
    }

    public class Coordinates
    {
        public int Row;
        public int Column;

        public Coordinates(int i, int j)
        {
            Row = i;
            Column = j;
        }
    }
}