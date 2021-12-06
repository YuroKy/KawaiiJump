using Assets.Scripts.Game.Bonuses;
using System;
using System.Collections.Generic;
using Assets.Scripts.Core.Constants;
using UnityEngine;

namespace Assets.Scripts.Game.Player
{
    public class EventDispatcher : MonoBehaviour
    {
        public event Action OnJump;
        public event Action<BaseBonus> OnTookBonus;

        private Dictionary<string, Action<GameObject>> _taggedCollisionHandlers;
        private Dictionary<string, Action<GameObject>> _taggedTriggerHandlers;

        private void Start()
        {
            _taggedCollisionHandlers = new Dictionary<string, Action<GameObject>>
            {
                { Tag.Platform, (_) => OnJump?.Invoke() },
            };

            _taggedTriggerHandlers = new Dictionary<string, Action<GameObject>>
            {
                { Tag.Bonus, (bonus) => OnTookBonus?.Invoke(bonus.GetComponent<BaseBonus>()) },
            };
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            _taggedCollisionHandlers.TryGetValue(collision.gameObject.tag, out var handler);

            handler?.Invoke(collision.gameObject);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            _taggedTriggerHandlers.TryGetValue(other.tag, out var handler);

            handler?.Invoke(other.gameObject);
        }
    }
}
