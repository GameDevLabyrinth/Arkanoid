using UnityEngine;

namespace GameDevLabirinth
{
    public class BallSpeedController : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody2D;
        private const float MinSpeed = 5.8f;
        private const float MaxSpeed = 6.2f;
        private const int WaitFrame = 30;

        private void Update()
        {
            if (_rigidbody2D.velocity.magnitude != 0)
            {
                if (Time.frameCount % WaitFrame == 0)
                {
                    if (_rigidbody2D.velocity.magnitude < MinSpeed || _rigidbody2D.velocity.magnitude > MaxSpeed)
                    {
                        float speedCorrect = MaxSpeed / _rigidbody2D.velocity.magnitude;
                        _rigidbody2D.velocity *= speedCorrect;
                    }
                }
            }
        }
    }
}