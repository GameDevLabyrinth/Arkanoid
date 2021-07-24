using UnityEngine;

namespace GameDevLabirinth
{
    public class BonusMove : MonoBehaviour
    {
        private const float Speed = 5f;

        private void Update()
        {
            transform.Translate(Vector3.down * Speed * Time.deltaTime);
        }
    }
}