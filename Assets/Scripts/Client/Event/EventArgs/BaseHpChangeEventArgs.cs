namespace Client.Event.EventArgs
{
    //基地Hp变化事件委托参数
    public class BaseHpChangeEventArgs : System.EventArgs
    {
        public int Damage { get; }

        public BaseHpChangeEventArgs(int damage)
        {
            Damage = damage;

        }
    }
}