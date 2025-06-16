using UnityEngine;

public class GameInstanceManager : MonoBehaviour
{
    public static GameInstanceManager Instance;

    public static GameplayTagManager GameplayTagManager;
    
    public static GameplayTagContainer PlayerGameInstanceTagContainer;
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // Prevent duplicates
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        
        GameplayTagManager = gameObject.AddComponent<GameplayTagManager>();
        
        PlayerGameInstanceTagContainer = gameObject.AddComponent<GameplayTagContainer>();
    }
}
