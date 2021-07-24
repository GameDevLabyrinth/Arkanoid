using UnityEngine;

namespace GameDevLabirinth
{
    public class WindowEnent : MonoBehaviour
    {
        [SerializeField] private GameState _gameState;
        [SerializeField] private GameObject _pauseButton;

        private void OnEnable()
        {
            _pauseButton.SetActive(false);
            _gameState.SetState(State.StopGame);
        }

        private void OnDisable()
        {
            _pauseButton.SetActive(true);
        }
    }
}