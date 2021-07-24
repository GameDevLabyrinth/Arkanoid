using System;
using UnityEngine;

namespace GameDevLabirinth
{
    public class PlayerInput : MonoBehaviour
    {
        public static event Action<float> OnMove;
        public static event Action OnClicked;

        private Vector2 _startPosition = Vector2.zero;
        private float _direction = 0f;

        private void Update()
        {
#if UNITY_EDITOR
            OnMove?.Invoke(Input.GetAxisRaw("Horizontal"));
            if (Input.GetKeyDown(KeyCode.Backspace))
            {
                OnClicked?.Invoke();
            }
#endif
#if UNITY_ANDROID
            GetTouchInput();
#endif
        }

        private void GetTouchInput()
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.tapCount > 1)
                {
                    OnClicked?.Invoke();
                }
                
                switch (touch.phase)
                {

                    case TouchPhase.Moved:
                        _direction = touch.position.x > _startPosition.x ? 1f : -1f;
                        break;
                    default:
                        _startPosition = touch.position;
                        _direction = 0f;
                        break;
                }
                OnMove?.Invoke(_direction);
            }
        }
    }
}