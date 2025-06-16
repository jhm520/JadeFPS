using Unity.Netcode;
using UnityEngine;

public class NetworkStarter : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (!NetworkManager.Singleton)
        {
            Destroy(gameObject);
        }
        
        if (!GameInstanceManager.Instance || GameInstanceManager.PlayerGameInstanceTagContainer.HasTagByName("GameplayTag/JadeFPS/Game/PlaySolo"))
        {
            //if the play solo tag is present, we don't need to start the network manager
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnGUI()
    {
        if (!NetworkManager.Singleton)
        {
            return;
        }
        
        if (!NetworkManager.Singleton.IsClient && !NetworkManager.Singleton.IsServer)
        {
            
            if (GameInstanceManager.Instance && GameInstanceManager.PlayerGameInstanceTagContainer.HasTagByName("GameplayTag/JadeFPS/Game/HostServer"))
            {
                GUI.Label(new Rect(10, 10, 300, 30), "Hosting a server...");
                NetworkManager.Singleton.StartHost();
            }
            
            if (GUI.Button(new Rect(10, 10, 150, 30), "Host")) NetworkManager.Singleton.StartHost();
            if (GUI.Button(new Rect(10, 50, 150, 30), "Client")) NetworkManager.Singleton.StartClient();
            if (GUI.Button(new Rect(10, 90, 150, 30), "Server")) NetworkManager.Singleton.StartServer();
        }
    }
}
