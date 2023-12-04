using UnityEngine;
using Unity.Netcode;

public class PrefabManager : NetworkBehaviour
{
    public GameObject hostPlayerPrefab;
    public GameObject clientPlayerPrefab;

    public void SpawnPlayer()
    {
        if (NetworkManager.Singleton.IsHost)
        {
            // Spawn host prefab
            GameObject hostObject = Instantiate(hostPlayerPrefab);
            hostObject.GetComponent<NetworkObject>().SpawnWithOwnership(NetworkManager.Singleton.LocalClientId);
        }
        else if (NetworkManager.Singleton.IsClient)
        {
            // Spawn client prefab
            GameObject clientObject = Instantiate(clientPlayerPrefab);
            clientObject.GetComponent<NetworkObject>().SpawnWithOwnership(NetworkManager.Singleton.LocalClientId);
        }
    }
}