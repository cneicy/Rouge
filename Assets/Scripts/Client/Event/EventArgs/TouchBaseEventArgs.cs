using Client.Object;

namespace Client.Event.EventArgs
{
    //敌人触碰到玩家事件委托参数 
    public class TouchBaseEventArgs : System.EventArgs
    {
        public Base Base { get; }

        public TouchBaseEventArgs(Base @base)
        {
            Base = @base;
        }
    }
}