using UnityEngine;

namespace GameDevLabirinth
{
    public class WindowController : MonoBehaviour
    {
        [SerializeField] private GameState _gameState;
        [SerializeField] private GameObject _endGameWindow;
        [SerializeField] private GameObject _pauseWindow;

        public void Play()
        {
            _gameState.SetState(State.Gameplay);
            _pauseWindow.SetActive(false);
        }

        public void Replay()
        {
            DisableTwoWindow();
        }

        public void NextLevel()
        {
            _endGameWindow.SetActive(false);
            // add logic
        }

        public void ToHome()
        {
            DisableTwoWindow();
            LoadingScreen.Screen.Enable(true);
            Loader loader = new Loader();
            _gameState.SetState(State.Other);
            loader.LoadingMainScene(true);
        }

        private void DisableTwoWindow()
        {
            _endGameWindow.SetActive(false);
            _pauseWindow.SetActive(false);
        }

        private void OnEnable()
        {
            Block.OnEnded += EndGame;
        }

        private void OnDisable()
        {
            Block.OnEnded -= EndGame;
        }

        private void EndGame()
        {
            if(_gameState.State == State.Gameplay)
            {
                _endGameWindow.SetActive(true);
            }
        }
    }
}