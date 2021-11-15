
using BattleShip_Game_ServiceLayer.Interfaces;

namespace BattleShip_Game_ServiceLayer.Services
{
    /// <summary>
    /// This class would assign players to the Game and let them play their respective turns and Show Boards after each turn.
    /// </summary>
    public class GamePlay : IGamePlay
    {
        public IPlayer Player1 { get; set; }
        
        public IPlayer Player2 { get; set; }
    
        public IPlayer PlayerInAction { get; set; }

        public void PlayTurn(int row, int column, IPlayer currentplayer)
        {
            Coordinates coordinates = new Coordinates(row, column);

            if (currentplayer == Player1)
            {
                Player2.SpotShot(coordinates);
                Player2.ShowBoards();
            }
            else
            {
                Player1.SpotShot(coordinates);
                Player1.ShowBoards();
            }
        }
    }
}
