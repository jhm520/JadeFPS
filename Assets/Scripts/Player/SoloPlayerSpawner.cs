using UnityEngine;

public class SoloPlayerSpawner : MonoBehaviour
{
    public GameObject playerPrefab;
    public Transform spawnPoint;

    void Start()
    {
        if (!GameInstanceManager.Instance || !GameInstanceManager.PlayerGameInstanceTagContainer.HasTagByName("GameplayTag/JadeFPS/Game/PlaySolo"))
        {
            Destroy(gameObject);
            return;
        }
        
        // If the PlaySolo tag is present, we can spawn the player
        SpawnPlayer();
       
    }

    void SpawnPlayer()
    {
        // Destroy any existing MainCamera in the scene
        Camera existingMainCam = Camera.main;
        if (existingMainCam != null)
        {
            Destroy(existingMainCam.gameObject);
        }
        
        spawnPoint = this.gameObject.transform;
        
        // Instantiate the player at the spawn point's position and rotation

        // Spawn the player prefab
        GameObject player = Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
        
        player.SetActive(true);

        // Find the camera in the spawned prefab
        Camera playerCam = player.GetComponentInChildren<Camera>();

        if (playerCam != null)
        {
            playerCam.tag = "MainCamera"; // Ensure Unity recognizes it as the main camera
            Camera.SetupCurrent(playerCam); 
            playerCam.enabled = true;

        }
        else
        {
            Debug.LogWarning("No camera found on the spawned player!");
        }
    }
}
