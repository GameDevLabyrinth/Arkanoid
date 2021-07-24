using System;
using System.Collections;
using UnityEngine;

namespace GameDevLabirinth
{
    public abstract class Bonus : MonoBehaviour
    {
        [SerializeField] protected int _score;
        [SerializeField] protected float _time = 4f;
        private float _currentTime;
        private const float TimeStep = 0.5f;
        public static event Action<int> OnAdded;

        public abstract void Apply();

        public void StopAndRemove()
        {
            if(TryGetComponent(out IRemovable removable))
            {
                removable.Remove();
            }
            Destroy(gameObject);
        }
        protected void StartTimer()
        {
            OnAdded?.Invoke(_score);
            _currentTime = _time;
            StartCoroutine(Timer());
        }

        private IEnumerator Timer()
        {
            while (_currentTime > 0)
            {
                _currentTime -= TimeStep;
                yield return new WaitForSeconds(TimeStep);
            }
            StopAndRemove();
        }
    }
}