using Client.Event;
using Client.Event.EventArgs;
using UnityEngine;

namespace Client.Object
{
    public class Enemy : MonoBehaviour
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
                EventCenter.Instance.TouchPlayer(player, player.GetPlayerID());
            }
        }

        private Player HandleTouchPlayer(TouchPlayerEventArgs e)
        {
            Debug.Log("HandleTouchPlayer");
            EventCenter.Instance.PlayerHpChange(-damage, e.PlayerID);
            return e.Player;
        }
    }
}