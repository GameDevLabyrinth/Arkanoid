using UnityEngine;

namespace GameDevLabirinth
{
    public class UfoGenerator : MonoBehaviour
    {
        private const float MinPositionY = -4.75f;
        private const float MaxPositionY = 8.75f;
        private ObjectPool _ufosPool;

        private void OnEnable()
        {
            if (_ufosPool == null)
            {
                ObjectPool[] objectPools = FindObjectsOfType<ObjectPool>();
                for (int i = 0; i < objectPools.Length; i++)
                {
                    if (objectPools[i].gameObject.CompareTag("UfosPool"))
                    {
                        _ufosPool = objectPools[i];
                        break;
                    }
                }
            }
        }

        public void Generate()
        {
            GameObject ufo = _ufosPool.GetObject();
            if (ufo != null)
            {
                float tempY = Random.Range(MinPositionY, MaxPositionY);
                ufo.transform.position = new Vector2(transform.position.x, tempY);
                ufo.SetActive(true);
            }
        }
    }
}