using BattleShip_Game_ServiceLayer.Enums;

namespace BattleShip_Game_ServiceLayer.Services
{
    public class Ship
    {
        public string Name { get; set; }
        public int ShipSize { get; set; }
        public ShipType ShipType { get; set; }
        public int Hits { get; set; }
        public bool IsSunk()
        {
            return Hits == ShipSize;
        }
    }

    internal class CarrierShip : Ship
    {
        public CarrierShip(string Name, int ShipSize)
        {
            this.Name = Name;
            this.ShipSize = ShipSize;
            ShipType = ShipType.Carrier;
        }
    }

    internal class DestroyerShip : Ship
    {
        public DestroyerShip(string Name, int ShipSize)
        {
            this.Name = Name;
            this.ShipSize = ShipSize;
            ShipType = ShipType.Destroyer;
        }
    }
}
