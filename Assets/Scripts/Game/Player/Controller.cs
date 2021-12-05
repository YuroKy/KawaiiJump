using Assets.Scripts.Game.Bonuses;
using Assets.Scripts.Tools.Constants;
using System;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Scripts.Game.Player
{
    public class Controller : MonoBehaviour
    {
        public event Action OnJump;
        public event Action<BaseBonus> OnTookBonus;

        private Dictionary<string, Action<GameObject>> _taggedColissionHandlers;

        private void Start()
        {
            _taggedColissionHandlers = new Dictionary<string, Action<GameObject>>
            {
                { Tag.Platform, (_) => OnJump.Invoke() },
                { Tag.Bonus, (bonus) => OnTookBonus(bonus.GetComponent<BaseBonus>()) },
            };

        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            _taggedColissionHandlers.TryGetValue(collision.gameObject.tag, out var handler);

            if (handler != null)
            {
                handler.Invoke(collision.gameObject);
            }
        }
    }
}
