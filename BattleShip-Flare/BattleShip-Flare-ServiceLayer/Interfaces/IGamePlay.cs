using System.Collections.Generic;

namespace BattleShip_Game_ServiceLayer.Interfaces
{
    public interface IGamePlay
    {    
        public IPlayer Player1 { get; set; }
        public IPlayer Player2 { get; set; }
        public IPlayer PlayerInAction { get; set; }  
        public void PlayTurn(int row, int column, IPlayer currentplayer);
    }
}
