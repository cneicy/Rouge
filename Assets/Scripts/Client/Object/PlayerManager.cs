using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Client.Object
{
    public class PlayerManager : MonoBehaviour
    {

        #region 单例
        private static readonly object Lock = new();
        private static PlayerManager _instance;
        public static PlayerManager Instance
        {
            get
            {
                lock (Lock)
                {
                    if (_instance != null) return _instance;
                    _instance = FindObjectOfType<PlayerManager>() ??
                                new GameObject("PlayerManager").AddComponent<PlayerManager>();
                    return _instance;
                }
            }
        }
        private void Awake()
        {
            if (_instance is not null && _instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                _instance = this;
            }

            StartCoroutine(AccessOnlinePlayer());
        }
        #endregion
        public List<Player> PlayerList;

        public GameObject LocalPlayer
        {
            get;
            private set;
        }
        
        //获取所有在线玩家，并标记本地玩家
        private IEnumerator AccessOnlinePlayer()
        {
            var obj = GameObject.FindGameObjectsWithTag("Player");
            var ptemp = new List<Player>();
            foreach (var player in obj)
            {
                if (player.GetComponent<Player>().IsLocalPlayer)
                {
                    LocalPlayer = player;
                }
                ptemp.Add(player.GetComponent<Player>());
            }

            PlayerList = ptemp;
            yield return new WaitForSeconds(1);
            StartCoroutine(AccessOnlinePlayer());
        }
    }
}
