using BattleShip_Game_ServiceLayer.Enums;
using BattleShip_Game_ServiceLayer.Services;
using System.Collections.Generic;

namespace BattleShip_Game_ServiceLayer.Interfaces
{
    public interface IPlayer
    {
        public string PlayerName { get; set; }
        public PlayBoard PlayBoard { get; set; }
        public List<Ship> Ships { get; set; }
        public void ShowBoards();
        public bool HasLost
        {
            get;
        }
        public Result SpotShot(Coordinates coordinates);    //Player1 will spot the shot  of player2 and vice versa
    }
}
