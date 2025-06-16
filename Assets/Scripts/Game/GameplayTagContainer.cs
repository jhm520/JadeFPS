using System.Collections.Generic;
using UnityEngine;

//this script is used to track gameplay tags as they are added/removed dynamically to game objects
public class GameplayTagContainer : MonoBehaviour
{
    
    private Dictionary<string, GameplayTag> _activeTagsDict = new Dictionary<string, GameplayTag>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void AddTagByName(string tagName)
    {
        GameplayTag tag = GameplayTagManager.GetTagByName(tagName);
        
        _activeTagsDict.TryAdd(tagName, tag);
    }
    
    public void RemoveTagByName(string tagName)
    {
        _activeTagsDict.Remove(tagName);
    }
    
    public bool HasTagByName(string tagName)
    {
        return _activeTagsDict.ContainsKey(tagName);
    }
}
