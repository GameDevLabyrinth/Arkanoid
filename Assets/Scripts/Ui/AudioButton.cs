using UnityEngine;
using UnityEngine.UI;

namespace GameDevLabirinth
{
    public class AudioButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [Space]
        [SerializeField] private Color _enableColor;
        [SerializeField] private Color _disableColor;
        [Space]
        [SerializeField] private Image _icon;
        [Space]
        [SerializeField] private Sprite _enableSprite;
        [SerializeField] private Sprite _disableSprite;
        private bool _enable;

        public void SetState(bool value)
        {
            _enable = value;
            Changed();
        }

        public void Change()
        {
            _enable = !_enable;
            Changed();
        }

        private void Changed()
        {
            _button.image.color = _enable ? _enableColor : _disableColor;
            _icon.sprite = _enable ? _enableSprite : _disableSprite;
        }
    }
}