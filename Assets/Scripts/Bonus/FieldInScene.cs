using UnityEngine;

namespace GameDevLabirinth
{
    public class FieldInScene : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private BoxCollider2D _boxCollider2;

        public void SetActive(bool value)
        {
            _boxCollider2.enabled = value;
            _spriteRenderer.enabled = value;
        }
    }
}