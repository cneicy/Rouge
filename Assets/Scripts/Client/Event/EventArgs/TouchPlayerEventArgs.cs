using Client.Object;

namespace Client.Event.EventArgs
{
    //敌人触碰到玩家事件委托参数 
    public class TouchPlayerEventArgs : System.EventArgs
    {
        public Player Player { get; }
        public ulong PlayerID { get; }

        public TouchPlayerEventArgs(Player player, ulong playerID)
        {
            Player = player;
            PlayerID = playerID;
        }
    }
}