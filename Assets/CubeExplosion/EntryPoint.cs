using UnityEngine;

namespace CubeExplosion
{
    public class EntryPoint : MonoBehaviour
    {
        private void Awake()
        {
            float xStartPoint = -15;
            float xEndPoint = 15;
            float ySpawnHeigh = 10;

            CubeFactory cubeFactory = new();

            int startCubeCount = 2;
            float startCubeScale = 4;
            float startSeparationChance = 100;

            for (int i = 0; i < startCubeCount; i++)
            {
                Vector3 spawnPoint = new(Random.Range(xStartPoint, xEndPoint), ySpawnHeigh, 0);
                cubeFactory.Create(spawnPoint, startCubeScale, startSeparationChance);
            }
        }
    }
}

