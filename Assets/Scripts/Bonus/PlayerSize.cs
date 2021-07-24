using UnityEngine;

namespace GameDevLabirinth
{
    public class PlayerSize : Bonus, IRemovable
    {
        [SerializeField] private bool _negative;
        private const float Size = 0.5f;

        public override void Apply()
        {
            StartTimer();
            SetSize(_negative ? -Size : Size);
        }

        public void Remove()
        {
            SetSize(_negative ? Size : -Size);
        }

        private void SetSize(float value)
        {
            PlayerMove player = GetComponentInParent<PlayerMove>();
            if (player != null)
            {
                if (player.TryGetComponent(out SpriteRenderer spriteRenderer))
                {
                    spriteRenderer.size = new Vector2(spriteRenderer.size.x + value, spriteRenderer.size.y);
                }
                if (player.TryGetComponent(out BoxCollider2D boxCollider2D))
                {
                    boxCollider2D.size = new Vector2(boxCollider2D.size.x + value, boxCollider2D.size.y);
                }
            }
        }
    }
}