using Client.Event;
using Client.Event.EventArgs;
using Unity.Netcode;
using UnityEngine;

namespace Client.Object
{
    public class Enemy : NetworkBehaviour
    {
        public Transform targetPoint;
        public float moveSpeed = 5f;
        public int hp;
        private void OnEnable()
        {
            EventCenter.Instance.OnTouchPlayer += HandleTouchPlayer;
            EventCenter.Instance.OnTouchBase += HandleTouchBase;
        }

        private void OnDisable()
        {
            EventCenter.Instance.OnTouchPlayer -= HandleTouchPlayer;
            EventCenter.Instance.OnTouchBase -= HandleTouchBase;
        }
        
        private void Update()
        {
            if (targetPoint is not null)
            {
                var direction = (targetPoint.position - transform.position).normalized;
                transform.Translate(direction * (moveSpeed * Time.deltaTime));
            }
        }

        public int damage = 1;

        //当触碰到玩家时执行TouchPlayer触发OnTouchPlayer事件，执行HandleTouchPlayer，执行PlayerHpChange触发OnPlayerHpChange
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<Player>(out var player))
            {
                EventCenter.Instance.TouchPlayer(player, player.playerID);
            }

            if (other.TryGetComponent<Base>(out var @base))
            {
                EventCenter.Instance.TouchBase(@base);
            }
        }

        private Player HandleTouchPlayer(TouchPlayerEventArgs e)
        {
            EventCenter.Instance.PlayerHpChange(-damage, e.PlayerID);
            return e.Player;
        }
        private Base HandleTouchBase(TouchBaseEventArgs e)
        {
            EventCenter.Instance.BaseHpChange(-damage, e.Base);
            return e.Base;
        }
    }
}