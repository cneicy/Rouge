using Client.Object;

namespace Client.Event.EventArgs
{
    //基地Hp变化事件委托参数
    public class BaseRuinedEventArgs : System.EventArgs
    {
        public Base Base { get; }

        public BaseRuinedEventArgs(Base @base)
        {
            Base = @base;
        }
    }
}