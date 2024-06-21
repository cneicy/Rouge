using Client.Event.EventArgs;

namespace Client.Event.EventHandler
{
    //玩家Hp变化事件委托
    public delegate int PlayerHpChangeEventHandler(PlayerHpChangeEventArgs e);
}