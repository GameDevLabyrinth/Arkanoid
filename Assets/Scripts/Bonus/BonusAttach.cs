using UnityEngine;

namespace GameDevLabirinth
{
    [RequireComponent(typeof(BonusMove), typeof(BoxCollider2D), typeof(SpriteRenderer))]
    public class BonusAttach : MonoBehaviour
    {
        [SerializeField] private BonusMove _bonusMove;
        [SerializeField] private BoxCollider2D _boxCollider2D;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [Space]
        [SerializeField] private Bonus _bonus;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out PlayerMove playerMove))
            {
                SetEnableMoveAndVisual(false);
                Bonus[] bonuses = playerMove.gameObject.GetComponentsInChildren<Bonus>();
                if (bonuses.Length > 0)
                {
                    foreach (var item in bonuses)
                    {
                        if (_bonus.GetType() == item.GetType())
                        {
                            item.StopAndRemove();
                            break;
                        }
                    }
                    Attach(playerMove.transform);
                }
                else
                {
                    Attach(playerMove.transform);
                }
            }
        }

        private void Attach(Transform parent)
        {
            transform.SetParent(parent);
            transform.position = parent.position;
            _bonus.Apply();
        }

        private void OnEnable()
        {
            SetEnableMoveAndVisual(false);
        }

        public void SetEnableMoveAndVisual(bool value)
        {
            _boxCollider2D.enabled = value;
            _spriteRenderer.enabled = value;
            _bonusMove.enabled = value;
        }
    }
}