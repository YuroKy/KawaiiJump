using Assets.Scripts.Game.Bonuses;
using System;
using UnityEngine;

namespace Assets.Scripts.Game.Player
{
    public class Stats : MonoBehaviour
    {
        public event Action<int> OnScoreUpdated;
        public event Action<BaseBonus> OnBonusApplied;

        private Controller _playerController;
        private int _score;

        private void Start()
        {
            _playerController = GetComponent<Controller>();
            _playerController.OnTookBonus += AquireBonus;
        }

        private void AquireBonus(BaseBonus bonus)
        {
            _score += bonus.BonusScore;
            OnScoreUpdated.Invoke(_score);
            OnBonusApplied.Invoke(bonus);
        }

        private void OnDestroy()
        {
            _playerController.OnTookBonus -= AquireBonus;
        }
    }
}
