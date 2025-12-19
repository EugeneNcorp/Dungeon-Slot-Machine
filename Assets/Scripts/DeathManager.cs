using UnityEngine;

public class DeathManager : MonoBehaviour
{
    public Player player;
    public DialogueManager DM;

    void Update()
    {
        if (player.playerHealth <= 0)
        {
            DM.ReloadScene();
        }
    }
}
