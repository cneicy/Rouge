using Client.Event;
using Client.Event.EventArgs;
using Unity.Netcode;
using UnityEngine;

namespace Client.Object
{
    public class Player : NetworkBehaviour
    {
        private int _hp = 4;

        #region 订阅
        
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
            Debug.Log("HandlePlayerHpChange");
            if (e.PlayerID != GetPlayerID()) return e.Hp;
            Debug.Log(_hp);
            return _hp += e.Hp;

        }
        //OnPlayerDie触发后执行HandlePlayerDie
        private void HandlePlayerDie(ulong playerID)
        {
            if (playerID == GetPlayerID())
            {
                Debug.Log("HandlePlayerDie");
            }
        }

        public int GetPlayerHp()
        {
            return _hp;
        }

        public ulong GetPlayerID()
        {
            return NetworkManager.Singleton.LocalClientId;
        }
    }
}