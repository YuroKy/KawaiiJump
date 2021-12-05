using UnityEngine;

namespace Assets.Scripts.Game.Bonuses
{
    public abstract class BaseBonus : MonoBehaviour
    {
        public abstract int BonusScore { get; }
    }
}
