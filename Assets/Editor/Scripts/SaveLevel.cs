using System.Collections.Generic;
using UnityEngine;

namespace GameDevLabirinth
{
    public class SaveLevel
    {
        public void Save(GameLevel gameLevel)
        {
            gameLevel.Blocks = new List<BlockObject>();
            BaseBlock[] baseBlocks = GameObject.FindObjectsOfType<BaseBlock>();

            foreach (var item in baseBlocks)
            {
                BlockObject blockObject = new BlockObject
                {
                    Position = item.gameObject.transform.position,

                    Block = item.BlockData
                };

                gameLevel.Blocks.Add(blockObject);
            }
        }
    }
}