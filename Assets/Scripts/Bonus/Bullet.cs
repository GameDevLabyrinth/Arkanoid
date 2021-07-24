using UnityEngine;

namespace GameDevLabirinth
{
    public class Bullet : MonoBehaviour
    {
        private const float Speed = 10f;

        private void Update()
        {
            transform.Translate(Vector3.up * Speed * Time.deltaTime);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out IDamageable damageable))
            {
                damageable.ApplyDamage();
            }
            gameObject.SetActive(false);
        }

    }
}