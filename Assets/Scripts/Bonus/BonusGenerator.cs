using System.Collections.Generic;
using UnityEngine;

namespace GameDevLabirinth
{
    public class BonusGenerator : MonoBehaviour
    {
        [SerializeField] private GameState _gameState;
        private readonly List<BonusAttach> _levelBonuses = new List<BonusAttach>();
        private readonly LevelIndex _levelIndex = new LevelIndex();

        public void Generate()
        {
            _levelBonuses.Clear();
            GameLevel gameLevel = Resources.Load<GameLevel>($"Levels/Level{_levelIndex.GetIndex()}");
            if (gameLevel != null)
            {
                foreach (var item in gameLevel.Bonuses)
                {
                    BonusAttach bonusAttach = Instantiate(item, transform);
                    bonusAttach.transform.position = transform.position;
                    _levelBonuses.Add(bonusAttach);
                }
            }
        }

        private void Activate(Vector2 position)
        {
            if (_levelBonuses.Count > 0)
            {
                int index = Random.Range(0, _levelBonuses.Count);
                _levelBonuses[index].transform.SetParent(null);
                _levelBonuses[index].transform.position = position;
                _levelBonuses[index].SetEnableMoveAndVisual(true);
                _levelBonuses.RemoveAt(index);
            }
        }

        private void OnEnable()
        {
            Block.OnDestroyedPosition += BonusChance;
        }

        private void OnDisable()
        {
            Block.OnDestroyedPosition -= BonusChance;
        }

        private void BonusChance(Vector2 position)
        {
            if (_gameState.State == State.Gameplay)
            {
                var chance = Random.Range(0, 100);
                if (chance > 70)
                {
                    Activate(position);
                }
            }
        }
    }
}