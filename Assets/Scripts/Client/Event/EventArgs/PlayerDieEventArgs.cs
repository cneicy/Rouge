using Client.Object;

namespace Client.Event.EventArgs
{
    //基地Hp变化事件委托参数
    public class PlayerDieEventArgs : System.EventArgs
    {
        public ulong PlayerID { get; }

        public PlayerDieEventArgs(ulong playerID)
        {
            PlayerID = playerID;
        }
    }
}