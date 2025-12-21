using UnityEngine;
using System.Collections.Generic;
public class FlagManager : MonoBehaviour
{
    private HashSet<string> _flags = new();

    public bool HasFlags(string flag)
    {
        return _flags.Contains(flag);
    }

    public void AddFlag(string flag)
    {
        if (string.IsNullOrEmpty(flag))
        {
            return;
        }
        _flags.Add(flag);
    }
    
    public void RemoveFlag(string flag)
    {
        if (string.IsNullOrEmpty(flag))
        {
            return;
        }
        _flags.Remove(flag);
    }
}
