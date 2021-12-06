using Assets.Scripts.Game.Bonuses;
using System;
using UnityEngine;

namespace Assets.Scripts.Game.Player
{
    public class Stats : MonoBehaviour
    {
        public event Action<int> OnScoreUpdated;
        public event Action<BaseBonus> OnBonusApplied;

        private EventDispatcher _playerEventDispatcher;
        private int _score;

        private void Start()
        {
            _playerEventDispatcher = GetComponent<EventDispatcher>();
            _playerEventDispatcher.OnTookBonus += AcquireBonus;
        }

        private void AcquireBonus(BaseBonus bonus)
        {
            _score += bonus.BonusScore;
            OnScoreUpdated?.Invoke(_score);
            OnBonusApplied?.Invoke(bonus);
        }

        private void OnDestroy()
        {
            _playerEventDispatcher.OnTookBonus -= AcquireBonus;
        }
    }
}
