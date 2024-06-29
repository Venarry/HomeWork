using UnityEngine;

namespace RainOfCube
{
    public class CubeFactory : ObjectPoolBehaviour<Cube>
    {
        private readonly Cube _prefab = Resources.Load<Cube>(PrefabsPath.CubeInRain);

        public Cube Create(Vector3 spawnPoint)
        {
            return CreatePoolObject(spawnPoint);
        }

        protected override Cube GetPrefab() =>
            _prefab;
    }
}
