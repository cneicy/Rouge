using Client.Event;
using Client.Event.EventArgs;
using Unity.Netcode;
using UnityEngine;

namespace Client.Object
{
    public class Player : NetworkBehaviour
    {
        public int hp = 4;
        public ulong playerID;
        public NetworkVariable<ulong> netID = new();
        public NetworkVariable<int> netHp = new();


        private void Update()
        {
            if (IsLocalPlayer)
            {
                UpdateStateServerRPC(OwnerClientId,hp);
                playerID = netID.Value;
            }
            else
            {
                playerID = netID.Value;
                hp = netHp.Value;
            }
        }

        [ServerRpc]
        private void UpdateStateServerRPC(ulong id, int hpArg)
        {
            netID.Value = id;
            netHp.Value = hpArg;
        }

        #region 订阅

        //todo 改良玩家死亡事件
        private void OnEnable()
        {
            EventCenter.Instance.OnPlayerHpChange += HandlePlayerHpChange;
            EventCenter.Instance.OnPlayerDie += HandlePlayerDie;
        }

        private void OnDisable()
        {
            EventCenter.Instance.OnPlayerHpChange -= HandlePlayerHpChange;
            EventCenter.Instance.OnPlayerDie -= HandlePlayerDie;
        }

        #endregion

        //OnPlayerHpChange触发后执行HandlePlayerHpChange
        private int HandlePlayerHpChange(PlayerHpChangeEventArgs e)
        {
            Debug.Log("Handle"+e.PlayerID);
            if (e.PlayerID != playerID) return 114514;//大于0即可
            if (hp <= 1)
            {
                HandlePlayerDie(e.PlayerID);
            }
            return hp += e.Damage;
        }

        //OnPlayerDie触发后执行HandlePlayerDie
        private void HandlePlayerDie(ulong playerIDArg)
        {
            if (playerIDArg == playerID)
            {
                Debug.Log("HandlePlayerDie " + playerIDArg);
            }
        }

        public int GetPlayerHp()
        {
            return hp;
        }
    }
}