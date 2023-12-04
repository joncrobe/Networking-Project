using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode.Transports.UTP;
using Unity.Networking.Transport.Relay;
using Unity.Services.Authentication;
using Unity.Services.Core;
using Unity.Services.Relay;
using Unity.Services.Relay.Models;


public class NetworkManagerUI : MonoBehaviour
{

   [SerializeField] private Button hostBtn;
   [SerializeField] private Button clientBtn;

    private async void Start()
    {
        await UnityServices.InitializeAsync();

        AuthenticationService.Instance.SignedIn += () =>
        {
            Debug.Log("Signed in" + AuthenticationService.Instance.PlayerId);
        };
        await AuthenticationService.Instance.SignInAnonymouslyAsync();
    }

    private void Awake() {
    hostBtn.onClick.AddListener(() => {
        NetworkManager.Singleton.StartHost();

    });
    clientBtn.onClick.AddListener(() => {
        NetworkManager.Singleton.StartClient();
    });
   }


}
