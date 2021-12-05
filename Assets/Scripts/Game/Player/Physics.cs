using Assets.Scripts.Tools.Constants;
using UnityEngine;

namespace Assets.Scripts.Game.Player
{
    public class Physics : MonoBehaviour
    {
        [SerializeField] private float _jumpForce;
        [SerializeField] private float _speed;

        private Controller _playerController;
        private Rigidbody2D _rb;

        private bool _isJumped = false;
        private float _horizontalAxis;

        private void Start()
        {
            _playerController = GetComponent<Controller>();
            _rb = GetComponent<Rigidbody2D>();
            _playerController.OnJump += Jump;
        }

        private void Update()
        {
            _horizontalAxis = Input.GetAxis(Axis.Horizontal);
        }

        private void FixedUpdate()
        {
            _rb.velocity = new Vector2(_horizontalAxis * _speed * Time.fixedDeltaTime * 100f, _rb.velocity.y);

            if (_isJumped)
            {
                _isJumped = false;
                _rb.AddForce(new Vector2(0, _jumpForce));
            }
        }

        private void Jump()
        {
            _isJumped = true;
        }

        private void OnDestroy()
        {
            _playerController.OnJump -= Jump;
        }
    }
}
