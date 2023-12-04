using UnityEngine;
using Unity.Netcode;

public class NetworkSpawner : NetworkBehaviour
{
    public PlayerSpawner prefabManager;

    public override void OnNetworkSpawn()
    {
        prefabManager.SpawnPlayer();
    }
}

