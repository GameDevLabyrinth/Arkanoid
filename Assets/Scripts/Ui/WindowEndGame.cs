using UnityEngine;
using UnityEngine.UI;

namespace GameDevLabirinth
{
    public class WindowEndGame : MonoBehaviour
    {
        [SerializeField] private CalculationLevelProgress _calculationLevel;
        [SerializeField] private Image _ribbonImage;
        [SerializeField] private Color _winColor;
        [SerializeField] private Color _defeatColor;
        [SerializeField] private Image _starImage;
        [SerializeField] private Sprite[] _starSprites;
        [SerializeField] private Text _scoreText;
        [SerializeField] private Text _recordText;
        [SerializeField] private Text _levelIndex;
        [SerializeField] private Button _buttonNextLvl;

        private void OnEnable()
        {
            EndGameData endGameData = _calculationLevel.GetEndGameData();
            if (endGameData.Life > 0)
            {
                _buttonNextLvl.interactable = true;
            }
            else
            {
                _buttonNextLvl.interactable = false;
            }

            _levelIndex.text = (endGameData.LevelIndex + 1).ToString();
            _ribbonImage.color = (endGameData.Life < 1) ? _defeatColor : _winColor;
            _starImage.sprite = _starSprites[endGameData.Life];
            _scoreText.text = endGameData.Score.ToString();
            _recordText.text = endGameData.Record.ToString();
        }
    }
}