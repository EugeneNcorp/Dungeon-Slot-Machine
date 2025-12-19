using UnityEngine;

public class Player : MonoBehaviour
{
  public string playerName;
  public float playerHealth = 100.0f;
  public int playerLevel = 1;
  public int moneyCount = 0;

  public FlagManager flagManager;

  void Update()
  {
    UpdateFlag();
  }
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
    CharacterController cc = GetComponent<CharacterController>();

    if (cc != null)
    {
      cc.enabled = false;
    }
    
    playerName = data.name;
    playerHealth = data.health;
    playerLevel = data.level;
    transform.position = data.playerPos;
    moneyCount = data.money;
    
    if (cc != null)
    {
      cc.enabled = true;
    }
  }

  public void AddMoney(int amount)
  {
    moneyCount += amount;
    Debug.Log($"Current Money Amount: {moneyCount}");
  }
  
  public void AddHealth(int amount)
  {
    playerHealth += amount;
    Debug.Log($"Current Health Amount: {playerHealth}");
  }

  private void UpdateFlag()
  {
    if (moneyCount >= 5)
    {
      flagManager.AddFlag("haveMoney");
    }
    else
    {
      flagManager.RemoveFlag("haveMoney");
    }
  }
}
