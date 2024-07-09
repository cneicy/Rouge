using Client.Event;
using Client.Event.EventArgs;
using Unity.Netcode;
using UnityEngine;

namespace Client.Object
{
    public class Enemy : NetworkBehaviour
    {
        public Transform targetPoint;  // 目标点的Transform组件
        public float moveSpeed = 5f;   // 移动速度
        private void OnEnable()
        {
            EventCenter.Instance.OnTouchPlayer += HandleTouchPlayer;
        }

        private void OnDisable()
        {
            EventCenter.Instance.OnTouchPlayer -= HandleTouchPlayer;
        }

        

        private void Update()
        {
            if (targetPoint != null)
            {
                //算敌人朝向目标点的方向向量
                //var direction = (targetPoint.position - transform.position).normalized;
                var direction = (Vector3.zero - transform.position).normalized;
                //移动敌人
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
    }
}