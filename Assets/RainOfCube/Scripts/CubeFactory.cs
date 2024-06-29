using UnityEngine;

namespace RainOfCube
{
    public class CubeFactory : ObjectPoolBehaviour<Cube>
    {
        private readonly Cube _prefab = Resources.Load<Cube>(PrefabsPath.CubeInRain);

        public Cube Create(Vector3 spawnPoint)
        {
            Cube cube = CreatePoolObject(spawnPoint);

            return cube;
        }

        protected override Cube GetPrefab() =>
            _prefab;
    }
}
