using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    [Header("Data")] 
    public DialogueDataBase dataBase;
    public FlagManager flagManager;
    public Player player;
    public GameManager GM;
    public string startNodeId;
    
    

    public delegate void DialogueUpdated(string speakerName, string dialogueText, List<DialogueChoice> choices);

    public event DialogueUpdated OnDialogueUpdated;
    public event System.Action OnDialogueEnded;

    private DialogueNode _currentDialogueNode;

    private void Start()
    {
        // GoToNode(startNodeId);
    }
    
    public void StartDialogue(DialogueDataBase database, string startNodeId)
    {
        dataBase = database;
        GoToNode(startNodeId);

        //Lock everything when dialogue started
        GM.GameFreeze();
    }

    private void EndDialogue()
    {  
        _currentDialogueNode = null; 
        OnDialogueEnded?.Invoke();
        
        //Unlock everything when dialogue ended
        GM.GameUnfreeze();
    }
    
    public void ReloadScene()
    {
        var currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    private bool IsChoiceAvailable(DialogueChoice choice)
    {
        foreach (var required in choice.RequiredFlags)
        {
            if (!flagManager.HasFlags(required))
            {
                return false;
            }
        }
      
        foreach (var forbidden in choice.ForbiddenFlags)
        {
            if (flagManager.HasFlags(forbidden))
            {
                return false;
            }
        }
        
        return true;
    }

    private List<DialogueChoice> FilterChoices(List<DialogueChoice> choices)
    {
        var result = new List<DialogueChoice>();

        foreach (var choice in choices)
        {
            if (IsChoiceAvailable(choice))
            {
                result.Add(choice);
            }
        }
        return result;
    }

    public void SelectChoice(int index)
    {
        var filtered = FilterChoices(_currentDialogueNode.Choices);
        var choice = filtered[index];

        foreach (var flag in choice.GrantFlags)
        {
            flagManager.AddFlag(flag);
        }

        if (player != null)
        {
            player.AddMoney(choice.Money);
            player.AddHealth(choice.Health);
        }
        
        if (choice.CloseDialogue)
        {
            EndDialogue();
            return;
        }

        if (choice.ReloadScene)
        {
            ReloadScene();
            return;
        }

        GoToNode(choice.NextNodeId);
    }

    public void GoToNode(string nodeId)
    {
        _currentDialogueNode = dataBase.GetNode(nodeId);

        if (_currentDialogueNode == null)
        {
            EndDialogue();
            return;
        }
        
        var filtered = FilterChoices(_currentDialogueNode.Choices);
        OnDialogueUpdated?.Invoke(_currentDialogueNode.SpeakerName, _currentDialogueNode.DialogueText, filtered);
    }
}
