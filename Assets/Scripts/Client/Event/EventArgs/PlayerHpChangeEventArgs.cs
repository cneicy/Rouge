namespace Client.Event.EventArgs
{
    //玩家Hp变化事件委托参数
    public class PlayerHpChangeEventArgs : System.EventArgs
    {
        public int Damage { get; }
        public ulong PlayerID { get; }

        public PlayerHpChangeEventArgs(int damage, ulong playerID)
        {
            Damage = damage;
            PlayerID = playerID;
        }
    }
}