using System.Collections.Generic;
using System.Linq;
using UnityEngine;

//singleton object to create and manage all gameplay tags that exist
public class GameplayTagManager : MonoBehaviour
{
    public static GameplayTagManager Instance;

    private Dictionary<string, GameplayTag> _allTagsDict = new Dictionary<string, GameplayTag>();
    
    public static GameplayTag CreateGameplayTag(string tagName)
    {
        GameplayTag newTag = GameplayTag.CreateTag(tagName);
        Instance._allTagsDict.Add(tagName, newTag);
        return newTag;
    }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        
        // Optionally, initialize with some default tags
        GameplayTagManager.CreateGameplayTag("GameplayTag/JadeFPS/Game/PlaySolo");
        GameplayTagManager.CreateGameplayTag("GameplayTag/JadeFPS/Game/HostServer");

    }
    
    public bool HasTag(GameplayTag tag)
    {
        return _allTagsDict.ContainsKey(tag.GetTagName());
    }
    
    public static GameplayTag GetTagByName(string tagName)
    {
        if (Instance == null)
        {
            Debug.LogError("GameplayTagManager instance is not initialized.");
            return null;
        }


        if (Instance._allTagsDict.TryGetValue(tagName, out GameplayTag tag))
        {
            return tag;
        }
        
        return null;
    }
    
}
