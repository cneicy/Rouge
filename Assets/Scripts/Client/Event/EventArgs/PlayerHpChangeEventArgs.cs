namespace Client.Event.EventArgs
{
    //玩家Hp变化事件委托参数
    public class PlayerHpChangeEventArgs : System.EventArgs
    {
        public int Hp { get; }
        public ulong PlayerID { get; }

        public PlayerHpChangeEventArgs(int hp, ulong playerID)
        {
            Hp = hp;
            PlayerID = playerID;
        }
    }
}