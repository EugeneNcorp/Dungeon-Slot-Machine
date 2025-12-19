using UnityEngine;

public class Player : MonoBehaviour
{
  public string playerName;
  public float playerHealth = 100.0f;
  public int playerLevel = 1;

  public int moneyCount = 0;
  
  public PlayerData ToData()
  {
    return new PlayerData
    {
      name = playerName,
      health = playerHealth,
      level = playerLevel,
      playerPos = transform.position
    };
  }

  public void FromData(PlayerData data)
  {
    CharacterController cc = GetComponent<CharacterController>();

    if (cc != null)
    {
      cc.enabled = false;
    }
    
    playerName = data.name;
    playerHealth = data.health;
    playerLevel = data.level;
    transform.position = data.playerPos;
    
    if (cc != null)
    {
      cc.enabled = true;
    }
  }

  public void AddMoney(int value)
  {
    moneyCount += value;
  }
}
