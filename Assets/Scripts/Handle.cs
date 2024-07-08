using System;
using Client.Data;
using Unity.Netcode;
using UnityEngine;

public class Handle : MonoBehaviour
{
    public GameObject enemy;
    public ClientData clientData;

    public void CreateEnemy()
    {
        var temp = Instantiate(enemy);
        temp.GetComponent<NetworkObject>().Spawn();
    }

    private void Start()
    {
        
    }
}