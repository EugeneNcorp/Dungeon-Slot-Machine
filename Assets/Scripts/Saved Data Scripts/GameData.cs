[System.Serializable]

    public class GameData
    {
        public string version = "v1.1";
        public string lastSaved;

        public PlayerData playerData = new();
    }
