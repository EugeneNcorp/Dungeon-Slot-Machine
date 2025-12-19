using UnityEngine;

public class NpcDialogeStarter : MonoBehaviour
{
   public DialogueManager DM;
   public DialogueDataBase DDB;
   public string startNodeId;

   private void OnMouseDown()
   {
      StartDialogue();
   }

   private void StartDialogue()
   {
      DM.StartDialogue(DDB, startNodeId);
   }
}
