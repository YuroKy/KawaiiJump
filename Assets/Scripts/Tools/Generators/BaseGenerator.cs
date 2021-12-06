using UnityEngine;

namespace Assets.Scripts.Tools.Generators
{
    public abstract class BaseGenerator : MonoBehaviour
    {
        [SerializeField] protected float GenerationDelay;
        [SerializeField] protected float MinGenerationPositionX;
        [SerializeField] protected float MaxGenerationPositionX;
        [SerializeField] protected float MinGenerationPositionY;
        [SerializeField] protected float MaxGenerationPositionY;
        [SerializeField] protected float MinFallingSpeed;
        [SerializeField] protected float MaxFallingSpeed;

        private float _currentGenerationDelay;

        public abstract void Generate();

        protected void Start()
        {
            _currentGenerationDelay = GenerationDelay;
        }

        protected void FixedUpdate()
        {
            TryGenerate();
        }

        private void TryGenerate()
        {
            _currentGenerationDelay -= Time.fixedDeltaTime;
            if (_currentGenerationDelay > 0)
            {
                return;
            }

            Generate();
            _currentGenerationDelay = GenerationDelay;
        }
    }
}
