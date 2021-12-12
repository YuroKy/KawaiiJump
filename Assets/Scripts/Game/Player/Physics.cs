using Assets.Scripts.Core.Constants;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts.Game.Player
{
    public class Physics : MonoBehaviour
    {
        [SerializeField] private float _jumpForce = 0;
        [SerializeField] private float _speed = 0;

        private EventDispatcher _playerEventDispatcher;
        private List<Controller> _playerControllers;
        private Rigidbody2D _rb;

        private bool _isJumped;
        private float _horizontalAxis;

        private void Start()
        {
            _playerEventDispatcher = GetComponent<EventDispatcher>();
            _playerControllers = FindObjectsOfType<Controller>().ToList();
            _rb = GetComponent<Rigidbody2D>();

            _playerEventDispatcher.OnJump += JumpHandler;
            _playerControllers.ForEach(pc => pc.OnClick += UpdateHorizontalAxis);
        }

        private void Update()
        {
            _horizontalAxis = _horizontalAxis != 0 ? _horizontalAxis : Input.GetAxis(Axis.Horizontal);
        }

        private void FixedUpdate()
        {
            Move();
            Jump();
        }

        private void Jump()
        {
            if (!_isJumped)
            {
                return;
            }

            _isJumped = false;
            _rb.velocity = new Vector2(0, _jumpForce);
        }

        private void Move()
        {
            _rb.velocity = new Vector2(_horizontalAxis * _speed * Time.fixedDeltaTime * 100f, _rb.velocity.y);
            _horizontalAxis = 0;
        }

        private void UpdateHorizontalAxis(float axis)
        {
            _horizontalAxis = axis;
        }

        private void JumpHandler()
        {
            _isJumped = true;
        }

        private void OnDestroy()
        {
            _playerEventDispatcher.OnJump -= JumpHandler;
            _playerControllers.ForEach(pc => pc.OnClick -= UpdateHorizontalAxis);

        }
    }
}
