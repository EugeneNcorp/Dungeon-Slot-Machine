using UnityEngine;

public class Player : MonoBehaviour
{
  public string playerName;
  public float playerHealth = 100.0f;
  public int playerLevel = 1;
  public int moneyCount = 0;

  public FlagManager flagManager;

  
  public PlayerData ToData()
  {
    return new PlayerData
    {
      name = playerName,
      health = playerHealth,
      level = playerLevel,
      playerPos = transform.position,
      money = moneyCount
    };
  }

  public void FromData(PlayerData data)
  {
    playerName = data.name;
    playerHealth = data.health;
    playerLevel = data.level;
    transform.position = data.playerPos;
    moneyCount = data.money;
  }

  public void AddMoney(int amount)
  {
    moneyCount += amount;
  }
  
  public void AddHealth(int amount)
  {
    playerHealth += amount;
  }
}
