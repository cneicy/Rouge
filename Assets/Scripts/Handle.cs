using Client.Data;
using Unity.Netcode;
using UnityEngine;

public class Handle : MonoBehaviour
{
    public GameObject enemy;
    public GameObject @base;
    public ClientData clientData;

    public void CreateEnemy()
    {
        Instantiate(enemy).GetComponent<NetworkObject>().Spawn();
    }

    public void CreateBase()
    {
        Instantiate(@base).GetComponent<NetworkObject>().Spawn();
    }
}