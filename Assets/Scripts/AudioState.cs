using UnityEngine;

namespace GameDevLabirinth
{
    public class AudioState
    {
        private AudioValues _audioValues = new AudioValues();
        private const string Key = "Audio";

        public AudioValues GetAudioValues()
        {
            if (PlayerPrefs.HasKey(Key))
            {
                _audioValues = JsonUtility.FromJson<AudioValues>(PlayerPrefs.GetString(Key));
            }
            else
            {
                Create();
            }

            return _audioValues;
        }

        public void EnableMusic(bool value)
        {
            _audioValues.Music = value;
            Save();
        }

        public void EnableSound(bool value)
        {
            _audioValues.Sound = value;
            Save();
        }

        public void Clear()
        {
            PlayerPrefs.DeleteKey(Key);
        }

        private void Create()
        {
            _audioValues.Music = true;
            _audioValues.Sound = true;
            Save();
        }

        private void Save()
        {
            string save = JsonUtility.ToJson(_audioValues);
            PlayerPrefs.SetString(Key, save);
            PlayerPrefs.Save();
        }
    }

    [System.Serializable]
    public class AudioValues
    {
        public bool Music;
        public bool Sound;
    }
}