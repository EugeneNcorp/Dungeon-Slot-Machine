using UnityEngine;

    public class GameManager: MonoBehaviour
    {
        public Player player;
        private GameData _currentData = new();

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.O))
            {
                SaveGame();
            }
            
            if (Input.GetKeyDown(KeyCode.P))
            {
                LoadGame();
            }
        }
        public void SaveGame()
        {
            _currentData.playerData = player.ToData();
            SaveManager.Save(_currentData);
            Debug.Log("Game Saved!");
        }

        public void LoadGame()
        {
            if (SaveManager.TryLoad(out _currentData))
            {
                player.FromData(_currentData.playerData);
                Debug.Log("Game Loaded");
            }
            else
            {
                Debug.Log("Game Saved");
                SaveGame();
            }
        }
        
    }
