using Assets.Scripts.Core.Components;
using UnityEngine;
#pragma warning disable CS0649

namespace Assets.Scripts.Tools.Generators
{
    public class BonusGenerator : BaseGenerator
    {
        [SerializeField] private GameObject[] _bonusPrefabs;

        public override void Generate()
        {
            var prefabIndex = Random.Range(0, _bonusPrefabs.Length);
            var bonusPrefab = _bonusPrefabs[prefabIndex];

            var positionX = Random.Range(MinGenerationPositionX, MaxGenerationPositionX);
            var positionY = Random.Range(MinGenerationPositionY, MaxGenerationPositionY);
            var position = new Vector3(positionX, positionY, 0);
            var fallingSpeed = Random.Range(MinFallingSpeed, MaxFallingSpeed);

            var bonus = Instantiate(bonusPrefab, position, Quaternion.identity);
            bonus.AddComponent<FallingPhysics>().Speed = fallingSpeed;
            bonus.SetActive(true);
        }
    }
}
