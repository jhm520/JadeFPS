using UnityEngine;

[CreateAssetMenu(fileName = "GameplayTag", menuName = "Gameplay/Tag")]
public class GameplayTag : ScriptableObject
{
    public static GameplayTag CreateTag(string tagName)
    {
        GameplayTag tag = ScriptableObject.CreateInstance<GameplayTag>();
        tag._tagName = tagName;
        return tag;
    }
    
    public override bool Equals(object obj)
    {
        if (obj is GameplayTag other)
            return _tagName == other._tagName;

        return false;
    }

    public override int GetHashCode()
    {
        return _tagName != null ? _tagName.GetHashCode() : 0;
    }
    
    public GameplayTag(string tagName)
    {
        _tagName = tagName;
    }
    
    public string GetTagName()
    {
        return _tagName;
    }
    
    private string _tagName;
}
