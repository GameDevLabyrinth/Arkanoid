using System.Collections.Generic;
using UnityEngine;

namespace GameDevLabirinth
{
    [CreateAssetMenu(fileName = "Level", menuName = "GameData/Create/GameLevel")]
    public class GameLevel : ScriptableObject
    {
        public List<BlockObject> Blocks = new List<BlockObject>();
        public List<BonusAttach> Bonuses = new List<BonusAttach>();
        public Sprite Background;
    }

    [System.Serializable]
    public class BlockObject
    {
        public Vector3 Position;
        public BlockData Block;
    }
}