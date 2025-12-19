using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "Dialogue/DilogueDataBase")]
public class DialogueDataBase: ScriptableObject
{
    public List<DialogueNode> Nodes = new();
    private Dictionary<string, DialogueNode> _lookUp;
    
    private void BuildNodeDictionary()
    {
        if (_lookUp != null)
        {
            return;
        }

        _lookUp = new Dictionary<string, DialogueNode>();
        foreach (var node in Nodes)
        {
            _lookUp.Add(node.NodeId, node);
        }
    }
    
    public DialogueNode GetNode(string id)
    {
        if (string.IsNullOrEmpty(id))
        {
            return null;
        }

        BuildNodeDictionary();
        _lookUp.TryGetValue(id, out var node);
        return node;
    }
}
