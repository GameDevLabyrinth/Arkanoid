using System.Collections.Generic;

namespace GameDevLabirinth
{
    [System.Serializable]
    public class LevelsProgress
    {
        public List<Progress> Levels = new List<Progress>();
    }
    [System.Serializable]
    public class Progress
    {
        public bool IsOpened;
        public int MaxScore;
        public int StarsCount;
    }
}