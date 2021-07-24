using UnityEngine;

namespace GameDevLabirinth
{
    public class BlockComposite : MonoBehaviour
    {
        public void ApplyDamage(Vector2 position)
        {
            Collider2D[] collider2Ds = Physics2D.OverlapCircleAll(position, 0.05f);
            if (collider2Ds.Length > 0)
            {
                foreach (var item in collider2Ds)
                {
                    if (item.TryGetComponent(out IDamageable damageable))
                    {
                        damageable.ApplyDamage();
                        //break;
                    }
                }
            }
        }
    }
}