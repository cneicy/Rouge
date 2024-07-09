using Client.Event.EventArgs;
using Client.Object;

namespace Client.Event.EventHandler
{
    //敌人触碰到基地事件委托
    public delegate Base TouchBaseEventHandler(TouchBaseEventArgs e);
}