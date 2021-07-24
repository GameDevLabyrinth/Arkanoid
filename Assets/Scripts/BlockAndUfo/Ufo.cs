using System;
using UnityEngine;

namespace GameDevLabirinth
{
    public class Ufo : MonoBehaviour, IDamageable
    {
        private const int Score = 500;
        private const float Speed = 3f;
        private float _maxDistance;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private BoxCollider2D _boxCollider2D;
        [SerializeField] private ParticleSystem _particleSystem;
        public static event Action<int> OnDestroyed;

        private void Update()
        {
            transform.Translate(Vector3.right * Speed * Time.deltaTime);
            if (transform.position.x > _maxDistance)
            {
                gameObject.SetActive(false);
            }
        }

        private void ShowObject(bool value)
        {
            _boxCollider2D.enabled = value;
            _spriteRenderer.enabled = value;
        }

        private void OnEnable()
        {
            ShowObject(true);
            _maxDistance = Math.Abs(transform.position.x);
        }

        public void ApplyDamage()
        {
            ShowObject(false);
            OnDestroyed?.Invoke(Score);
            _particleSystem.Play();
        }
    }
}