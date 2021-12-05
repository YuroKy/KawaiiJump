using Assets.Scripts.Game.Bonuses;
using Assets.Scripts.Game.Player;
using UnityEngine;

namespace Assets.Scripts.Tools.GarbageCollectors
{
    public class BonusCollector : MonoBehaviour
    {
        private Stats _playerStats;

        private void Start()
        {
            _playerStats = FindObjectOfType<Stats>();
            _playerStats.OnBonusApplied += RemoveBonusGameObject;
        }

        private void RemoveBonusGameObject(BaseBonus bonus)
        {
            Destroy(bonus.gameObject);
        }

        private void OnDestroy()
        {
            _playerStats.OnBonusApplied -= RemoveBonusGameObject;
        }
    }
}
