using UnityEngine;

namespace GameDevLabirinth
{
    public class BallMove : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody2D;
        private bool _isActiv;
        private const float Force = 300f;
        [SerializeField] private BallSound _ballSound;

        private void OnEnable()
        {
            _rigidbody2D.bodyType = RigidbodyType2D.Kinematic;
            PlayerInput.OnClicked += BallActivete;
        }

        private void OnDisable()
        {
            PlayerInput.OnClicked -= BallActivete;
        }

        private void BallActivete()
        {
            if (!_isActiv)
            {
                _isActiv = true;
                transform.SetParent(null);
                _rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
                AddForce();
                _ballSound.PlaySoundAwake();
            }
        }
 
        public void AddForce(float direction = 0f)
        {
            _rigidbody2D.velocity = Vector2.zero;
            _rigidbody2D.AddForce(new Vector2(direction * (Force / 2), Force));
        }

        public void StartClone(float direction )
        {
            _isActiv = true;
            _rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
            AddForce(direction);
            _ballSound.PlaySoundAwake();
        }
    }
}