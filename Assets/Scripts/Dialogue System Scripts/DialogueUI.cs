using UnityEngine;
using TMPro;
using System.Collections.Generic;
using UnityEngine.UI;
public class DialogueUI : MonoBehaviour
{
   public DialogueManager DM;
   public GameObject dPanel;
   public TextMeshProUGUI SpeakerTextDisplay;
   public TextMeshProUGUI DialogueTextDisplay;
   public List<Button> Buttons;
   public List<TextMeshProUGUI> ButtonLabels;
   
   
   private void OnEnable()
   {
      DM = FindFirstObjectByType<DialogueManager>();
            
      if (DM != null)
      {
         DM.OnDialogueUpdated += UpdateUI;
         DM.OnDialogueEnded += Hide;
      }
   }

   private void OnDisable()
   {
      if (DM != null)
      {
         DM.OnDialogueUpdated -= UpdateUI;
         DM.OnDialogueEnded -= Hide;
      }
   }

   public void Hide()
   {
      dPanel.SetActive(false);
   }

   public void UpdateUI(string speaker, string dialogue, List<DialogueChoice> choices)
   {
      dPanel.SetActive(true);
      
      SpeakerTextDisplay.text = speaker;
      DialogueTextDisplay.text = dialogue;

      for (int i = 0; i < Buttons.Count; i++)
      {
         if (i < choices.Count)
         {
            Buttons[i].gameObject.SetActive(true);
            ButtonLabels[i].text = choices[i].ChoiceText;
         }
         else
         {
            Buttons[i].gameObject.SetActive(false);
         }
      }
   }
}
