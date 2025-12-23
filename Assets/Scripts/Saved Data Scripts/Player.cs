using UnityEngine;

public class Player : MonoBehaviour
{
  public string playerName;
  public float maxHealth = 100.0f;
  public float currentHealth;
  public int playerLevel = 1;
  public int moneyCount = 0;
  
  public HealthBar healthBar;
  public FlagManager flagManager;

  void Awake()
  {
    //Health and health bar settings
    currentHealth = maxHealth;
    healthBar.SetMaxHealth(maxHealth);
  }
  
  public PlayerData ToData()
  {
    return new PlayerData
    {
      //data that would be saved
      name = playerName,
      health = currentHealth,
      level = playerLevel,
      playerPos = transform.position,
      money = moneyCount
    };
  }

  public void FromData(PlayerData data)
  {
    //data that would be loaded
    playerName = data.name;
    currentHealth = data.health;
    playerLevel = data.level;
    transform.position = data.playerPos;
    moneyCount = data.money;
  }

  public void AddMoney(int amount)
  {
    moneyCount += amount;
     StatusFlagGiver("haveMoney", moneyCount, 5);
  }
  
  public void AddHealth(int amount)
  {
    currentHealth += amount;
    
    healthBar.SetTargetHealth(currentHealth);
  }

  public void StatusFlagGiver(string givenFlag, int statusVar, int threshold)
  {
    if (statusVar > threshold)
    {
      flagManager.AddFlag(givenFlag);
    }
    else
    {
      flagManager.RemoveFlag(givenFlag);
    }
  }
}
