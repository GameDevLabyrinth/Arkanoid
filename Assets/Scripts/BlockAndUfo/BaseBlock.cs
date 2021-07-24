using UnityEngine;

namespace GameDevLabirinth
{
    public abstract class BaseBlock : MonoBehaviour
    {
#if UNITY_EDITOR
        [HideInInspector]
        public BlockData BlockData;
#endif
    }
}