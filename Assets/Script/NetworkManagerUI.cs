using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class NetworkManagerUI : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Button serverBtn;
    [SerializeField] private UnityEngine.UI.Button hostBtn;
    [SerializeField] private UnityEngine.UI.Button clientBtn;

    private delegate string Test(int value);

    private Test _runner;
    
    

    private void Awake()
    {
        
        serverBtn.onClick.AddListener(() => NetworkManager.Singleton.StartServer());
        hostBtn.onClick.AddListener(() => NetworkManager.Singleton.StartHost());
        clientBtn.onClick.AddListener(() => NetworkManager.Singleton.StartClient());
    }

    private void Action()
    {
        NetworkManager.Singleton.StartHost();
    }
}
