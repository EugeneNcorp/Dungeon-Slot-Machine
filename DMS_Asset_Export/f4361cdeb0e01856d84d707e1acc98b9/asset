using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "Dialogue/DialogueNode")]

public class DialogueNode : ScriptableObject
{
    [Header("Identity")]
    public string NodeId; //speaker_01_descriptor

    [Header("Dialogue")] 
    public string SpeakerName;

    [TextArea(2, 5)]
    public string DialogueText;


    [Header("Choices")] 
    public List<DialogueChoice> Choices = new List<DialogueChoice>();
}

[System.Serializable]
public class DialogueChoice 
{
    [Header("UI")]
    public string ChoiceText;

    [Header("Flow")]
    public string NextNodeId;
    public bool ReloadScene;
    public bool CloseDialogue;
    [Header("Stats")] 
    public int Health;
    public int Money;
    

    [Header("Conditions")] 
    public List<string> RequiredFlags = new List<string>();
    public List<string> ForbiddenFlags = new List<string>();

    [Header("Flags On Select")]
    public List<string> GrantFlags = new List<string>();

}

