using System;
using UnityEngine;
using UnityEngine.EventSystems;
#pragma warning disable CS0649

namespace Assets.Scripts.Game.Player
{
    public class Controller : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] private Core.Enums.MoveDirection _moveDirection;

        public event Action<float> OnClick;
        private bool _isButtonPressed;

        private void FixedUpdate()
        {
            if (!_isButtonPressed)
            {
                return;
            }

            OnClick?.Invoke((int)_moveDirection);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _isButtonPressed = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _isButtonPressed = false;
        }
    }
}
