using UnityEngine;

namespace GameDevLabirinth
{
    public class BallCollisions : MonoBehaviour
    {
        [SerializeField] private BallMove _ball;
        [SerializeField] private BallSound _ballSound;
        private float _lastPositionX;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            _ballSound.PlaySoundCollision();
            float ballPositionX = transform.position.x;

            if (collision.gameObject.TryGetComponent(out PlayerMove playerMove))
            {
                if (ballPositionX < _lastPositionX + 0.1 && ballPositionX > _lastPositionX - 0.1) // движение почти вертикальное
                {
                    float collisionPointX = collision.contacts[0].point.x; // точка касания
                    float playerCenterPosition = playerMove.gameObject.transform.position.x;
                    float difference = playerCenterPosition - collisionPointX; // разница между центром ваганетки и местом касания
                    float direction = collisionPointX < playerCenterPosition ? -1 : 1; // расчет направления 
                    _ball.AddForce(direction * Mathf.Abs(difference));
                }
            }
            _lastPositionX = ballPositionX;

            if (collision.gameObject.TryGetComponent(out IDamageable damageable))
            {
                damageable.ApplyDamage();
            }

            if(collision.gameObject.TryGetComponent(out BlockComposite blockComposite))
            {
                blockComposite.ApplyDamage(collision.contacts[0].point);
            }
        }
    }
}