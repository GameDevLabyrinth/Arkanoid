using UnityEngine;

namespace GameDevLabirinth
{
    public class LevelsData
    {
        private const string KeyName = "Save";
        private LevelsProgress _levelsProgres = new LevelsProgress();

        private void SaveData()
        {
            string saveJson = JsonUtility.ToJson(_levelsProgres);
            PlayerPrefs.SetString(KeyName, saveJson);
            PlayerPrefs.Save();
        }

        public void NewData()
        {
            var levelsCount = Resources.LoadAll<GameLevel>("Levels").Length;

            for (int i = 0; i < levelsCount; i++)
            {
                _levelsProgres.Levels.Add(new Progress());
            }

            _levelsProgres.Levels[0].IsOpened = true;
            SaveData();
            Resources.UnloadUnusedAssets();
        }

        public LevelsProgress GetLevelsProgress()
        {
            if (PlayerPrefs.HasKey(KeyName))
            {
                string saveJson = PlayerPrefs.GetString(KeyName);
                _levelsProgres = JsonUtility.FromJson<LevelsProgress>(saveJson);
            }
            else
            {
                NewData();
            }
            return _levelsProgres;
        }

        public void SaveLevelData(int index, Progress progress)
        {
            _levelsProgres = GetLevelsProgress();
            _levelsProgres.Levels[index] = progress;
            if (index < _levelsProgres.Levels.Count - 1)
            {
                _levelsProgres.Levels[index + 1].IsOpened = true;
            }
            SaveData();
        }

        public void Clear()
        {
            PlayerPrefs.DeleteKey(KeyName);
        }
    }
}