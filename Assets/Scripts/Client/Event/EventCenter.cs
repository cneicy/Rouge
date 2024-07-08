using System;
using Client.Event.EventArgs;
using Client.Event.EventHandler;
using Client.Object;
using UnityEngine;

namespace Client.Event
{
    public class EventCenter : MonoBehaviour
    {
        #region 单例

        private static readonly object Lock = new();
        private static EventCenter _instance;

        public static EventCenter Instance
        {
            get
            {
                lock (Lock)
                {
                    if (_instance != null) return _instance;
                    _instance = FindObjectOfType<EventCenter>() ??
                                new GameObject("EventCenter").AddComponent<EventCenter>();
                    return _instance;
                }
            }
        }

        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                _instance = this;
            }
        }

        #endregion

        //定义事件
        public event PlayerHpChangeEventHandler OnPlayerHpChange;
        public event Action<ulong> OnPlayerDie;
        public event TouchPlayerEventHandler OnTouchPlayer;

        //玩家HP变化 血量归零时执行PlayerDie，触发OnPlayerDie
        public int? PlayerHpChange(int damage, ulong playerID)
        {
            Debug.Log(playerID);
            var newHp = OnPlayerHpChange?.Invoke(new PlayerHpChangeEventArgs(damage, playerID));
            return newHp;
        }
        

        //触摸玩家
        public Player TouchPlayer(Player player, ulong playerID)
        {
            return OnTouchPlayer?.Invoke(new TouchPlayerEventArgs(player, playerID));
        }
    }
}