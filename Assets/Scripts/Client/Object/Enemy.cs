using Client.Event;
using Client.Event.EventArgs;
using Unity.Netcode;
using UnityEngine;

namespace Client.Object
{
    public class Enemy : NetworkBehaviour
    {
        private void OnEnable()
        {
            EventCenter.Instance.OnTouchPlayer += HandleTouchPlayer;
        }

        private void OnDisable()
        {
            EventCenter.Instance.OnTouchPlayer -= HandleTouchPlayer;
        }

        public int damage = 1;

        //当触碰到玩家时执行TouchPlayer触发OnTouchPlayer事件，执行HandleTouchPlayer，执行PlayerHpChange触发OnPlayerHpChange
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<Player>(out var player))
            {
                Debug.Log("Trigger" + player.playerID);
                EventCenter.Instance.TouchPlayer(player, player.playerID);
            }
        }

        private Player HandleTouchPlayer(TouchPlayerEventArgs e)
        {
            Debug.Log("HandleTouchPlayer" + e.PlayerID);
            EventCenter.Instance.PlayerHpChange(-damage, e.PlayerID);
            return e.Player;
        }
    }
}