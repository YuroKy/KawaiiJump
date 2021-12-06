using Assets.Scripts.Core.Components;
using UnityEngine;

#pragma warning disable CS0649

namespace Assets.Scripts.Tools.Generators
{
    internal class PlatformGenerator : BaseGenerator
    {
        [SerializeField] private GameObject _platformPrefab;

        public override void Generate()
        {
            var positionX = Random.Range(MinGenerationPositionX, MaxGenerationPositionX);
            var position = new Vector3(positionX, MaxGenerationPositionY, 0);
            var fallingSpeed = Random.Range(MinFallingSpeed, MaxFallingSpeed);

            var platform = Instantiate(_platformPrefab, position, Quaternion.identity);
            platform.AddComponent<FallingPhysics>().Speed = fallingSpeed;
        }
    }
}
