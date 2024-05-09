using UnityEngine;

namespace CubeExplosion
{
    public class EntryPoint : MonoBehaviour
    {
        private void Awake()
        {
            float startWidth = -15;
            float endWidth = 15;
            float spawnHeigh = 0;

            CubeFactory cubeFactory = new();

            int startCubeCount = 2;
            float startCubeScale = 4;
            float startSeparationChance = 100;

            for (int i = 0; i < startCubeCount; i++)
            {
                Vector3 spawnPoint = new(Random.Range(startWidth, endWidth), spawnHeigh, Random.Range(startWidth, endWidth));
                cubeFactory.Create(spawnPoint, startCubeScale, startSeparationChance);
            }
        }
    }
}

