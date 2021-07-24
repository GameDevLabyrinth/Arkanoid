using UnityEngine;
using UnityEngine.Events;

namespace GameDevLabirinth
{
    public class ScoreController : MonoBehaviour
    {
        [SerializeField] private GameState _gameState;
        [SerializeField] private UnityEventInt UiUpdate;
        [SerializeField] private UnityEvent ThousandCollected;
        private const int ScoreToNextBonus = 1000;
        private int _score;

        public int GetScore()
        {
            return _score;
        }

        public void SetDefault()
        {
            _score = 0;
            UiUpdate.Invoke(_score);
        }

        private void OnEnable()
        {
            Block.OnDestroyed += ScoreCollect;
            Bonus.OnAdded += ScoreCollect;
            Ufo.OnDestroyed += ScoreCollect;
        }

        private void OnDisable()
        {
            Block.OnDestroyed -= ScoreCollect;
            Bonus.OnAdded -= ScoreCollect;
            Ufo.OnDestroyed -= ScoreCollect;
        }

        private void ScoreCollect(int value)
        {
            if (_gameState.State == State.Gameplay)
            {
                _score += value;
                UiUpdate.Invoke(_score);
                if (_score % ScoreToNextBonus == 0)
                {
                    ThousandCollected.Invoke();
                }
            }
        }
    }
}