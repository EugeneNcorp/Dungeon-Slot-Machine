using UnityEngine;
using UnityEngine.SceneManagement;

    public class GameManager: MonoBehaviour
    {
        public Player player;
        [SerializeField] private CharacterController cc;
        [SerializeField] private MouseLook camRotate;
        [SerializeField] private HeadBobController headBob;
        [SerializeField] private GameObject crosshair;
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
            
            if (player.currentHealth <= 0)
            { 
                ReloadScene();
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

        private void ReloadScene()
        {
            var currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.name);
        }

        public void GameFreeze()
        {
            //Lock movement + camera + crosshair
            cc.enabled = false;
            camRotate.canLook = false;
            headBob.enabled = false;
            crosshair.SetActive(false);
           
            //Unlock cursor
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        public void GameUnfreeze()
        {
            //Unlock movement + camera + crosshair
            cc.enabled = true;
            camRotate.canLook = true;
            headBob.enabled = true;
            crosshair.SetActive(true);
            
            //Lock cursor back
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
