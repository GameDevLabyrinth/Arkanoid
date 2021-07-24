using UnityEngine;
using UnityEngine.Events;

namespace GameDevLabirinth
{
    public class PlayerLife : MonoBehaviour
    {
        private const int MAX_LIFE = 3;
        private int _life;
        [SerializeField] private GameState _gameState;
        [SerializeField] private UnityEvent OnAllLifeLosted;
        [SerializeField] private UnityEvent OnLifeLosted;
        [SerializeField] private UnityEventInt UiUpdate;

        
        public int GetLifeCount()
        {
            return _life;
        }
        public void SetDefault()
        {
            _life = MAX_LIFE;
            UiUpdate.Invoke(_life);
        }

        private void OnEnable()
        {
            BallCount.OnEnded += LostLife;
        }

        private void OnDisable()
        {
            BallCount.OnEnded -= LostLife;
        }

        private void LostLife()
        {
            if (_gameState.State == State.Gameplay)
            {
                _life--;
                if (_life < 1)
                {
                    OnAllLifeLosted.Invoke();
                }
                else
                {
                    OnLifeLosted.Invoke();
                }

                UiUpdate.Invoke(_life);
            }
        }
    }

    [System.Serializable]
    public class UnityEventInt : UnityEvent<int> { }
}