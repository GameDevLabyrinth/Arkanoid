using UnityEngine;

namespace GameDevLabirinth
{
    public class EditorGrid
    {
        private const float _leftPosition = -4.5f;
        private const float _upPosition = 8.75f;
        private const int _columnCount = 10;
        private const int _lineCount = 20;
        private const float _offsetDown = 0.5f;
        private const float _offsetRight = 1f;

        public Vector3 CheckPotision(Vector3 position)
        {
            float tempX = 0;
            float tempY = 0;
            float x = _leftPosition - _offsetRight / 2;
            float y = _upPosition + _offsetDown / 2;

            if (position.x > x && position.x < (x + _offsetRight * _columnCount) &&
                position.y < y && position.y > (y - _offsetDown * _lineCount))
            {
                for (int i = 0; i < _columnCount; i++)
                {
                    if (position.x > x && position.x < (x + _offsetRight))
                    {
                        tempX = x + _offsetRight / 2;
                        break;
                    }
                    else
                    {
                        x += _offsetRight;
                    }
                }

                for (int i = 0; i < _lineCount; i++)
                {
                    if (position.y < y && position.y > (y - _offsetDown))
                    {
                        tempY = y - _offsetDown / 2;
                        break;
                    }
                    else
                    {
                        y -= _offsetDown;
                    }
                }
            }
            else
            {
                Debug.LogWarning("out of play zone");
            }

            return new Vector3(tempX, tempY);
        }
    }
}