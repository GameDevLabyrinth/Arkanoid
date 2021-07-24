using System;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

namespace GameDevLabirinth
{
    public class Block : BaseBlock, IDamageable
    {
        private static int _count = 0;
        [HideInInspector]
        [SerializeField] private List<Sprite> _sprites;
        [HideInInspector]
        [SerializeField] private int _score;
        [HideInInspector]
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [HideInInspector]
        [SerializeField] private int _life;
        [SerializeField] private BoxCollider2D _blockCollider;
        [SerializeField] private BoxCollider2D _composite;
        [SerializeField] private ParticleSystem _particleSystem;

        public static event Action OnEnded;
        public static event Action<int> OnDestroyed;
        public static event Action<Vector2> OnDestroyedPosition;

        public void SetData(ColoredBlock blockData)
        {
            _sprites = new List<Sprite>(blockData.Sprites);
            _score = blockData.Score;
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _life = _sprites.Count;
            _spriteRenderer.sprite = _sprites[_life - 1];
            MainModule main = GetComponent<ParticleSystem>().main;
            main.startColor = _spriteRenderer.color = blockData.BaseColor;
        }

        public void ApplyDamage()
        {
            _life--;
            if (_life < 1)
            {
                _spriteRenderer.enabled = false;
                _blockCollider.enabled = false;
                _composite.enabled = false;
                OnDestroyedPosition?.Invoke(transform.position);
                _particleSystem.Play();
            }
            else
            {
                _spriteRenderer.sprite = _sprites[_life - 1];
            }
        }

        private void OnEnable()
        {
            _count++;
        }

        private void OnDisable()
        {
            _count--;
            OnDestroyed?.Invoke(_score);

            if (_count < 1)
            {
                OnEnded?.Invoke();
            }
        }
    }
}