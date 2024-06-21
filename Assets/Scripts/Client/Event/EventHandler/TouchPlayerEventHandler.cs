using Client.Event.EventArgs;
using Client.Object;

namespace Client.Event.EventHandler
{
    //敌人触碰到玩家事件委托
    public delegate Player TouchPlayerEventHandler(TouchPlayerEventArgs e);
}