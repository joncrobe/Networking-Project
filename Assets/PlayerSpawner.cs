using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PlayerSpawner : NetworkBehaviour {
    public Transform playerPrefabA;
    public Transform playerPrefabB;

    private void Start()
    {
        SpawnPlayer();
    }

    public void SpawnPlayer()
    {
        if (IsServer)
        {
            // Spawn host player
            Transform hostPlayer = Instantiate(playerPrefabA, new Vector3(0, 0, 0), Quaternion.identity);
            hostPlayer.GetComponent<NetworkObject>().SpawnAsPlayerObject(NetworkManager.Singleton.LocalClientId);
        }
        else if (IsClient)
        {
            // Spawn client player
            Transform clientPlayer = Instantiate(playerPrefabB, new Vector3(0, 0, 0), Quaternion.identity);
            clientPlayer.GetComponent<NetworkObject>().SpawnAsPlayerObject(NetworkManager.Singleton.LocalClientId);
        }
    }
}
