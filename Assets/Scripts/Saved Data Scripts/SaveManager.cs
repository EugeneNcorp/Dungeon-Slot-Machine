using UnityEngine;
using System;
using System.IO;
[System.Serializable]

    public class SaveManager
    {
        private static readonly string FilePath = Application.persistentDataPath + "/GameSaveData.json";

        public static void Save(GameData data)
        {
            data.version = Application.version;
            data.lastSaved = DateTime.UtcNow.ToString("o");

            string json = JsonUtility.ToJson(data, true);
            File.WriteAllText(FilePath, json);
            Debug.Log($"[SaveManager] save game data to {FilePath}");
        }
        
        public static GameData Load()
        {
            TryLoad(out GameData data);
            return data;
        }

        public static bool TryLoad(out GameData data)
        {
            try
            {
                if (!File.Exists(FilePath))
                {
                    data = new GameData();
                    return false;
                }

                string json = File.ReadAllText(FilePath);
                data = JsonUtility.FromJson<GameData>(json);
                return true;
            }
            catch(Exception  e)
            {
                Debug.LogError($"[SaveManager] Load failed: {e.Message}");
                data = new GameData();
                return false;
            }
            
        }
    }
