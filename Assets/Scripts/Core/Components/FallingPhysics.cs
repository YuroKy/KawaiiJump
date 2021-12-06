using UnityEngine;

namespace Assets.Scripts.Core.Components
{
    public class FallingPhysics : MonoBehaviour
    {
        [SerializeField] public float Speed = 0;
        private Rigidbody2D _rb;

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
        }


        private void FixedUpdate()
        {
            Move();
        }

        private void Move()
        {
            _rb.velocity = new Vector2(0, Speed * Time.fixedDeltaTime * 100f * -1);
        }
    }
}
