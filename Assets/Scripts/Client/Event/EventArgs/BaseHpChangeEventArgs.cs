﻿using Client.Object;

namespace Client.Event.EventArgs
{
    //基地Hp变化事件委托参数
    public class BaseHpChangeEventArgs : System.EventArgs
    {
        public int Damage { get; }
        public Base Base { get; }

        public BaseHpChangeEventArgs(int damage,Base @base)
        {
            Damage = damage;
            Base = @base;
        }
    }
}