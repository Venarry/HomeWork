using UnityEngine;

namespace CubeExplosion
{
    public class CubeFactory
    {
        private readonly CubeView _prefab = Resources.Load<CubeView>(PrefabsPath.ExplosionCube);

        public CubeView Create(Vector3 position, float scale, float separationChance)
        {
            CubeView cubeView = Object.Instantiate(_prefab, position, Quaternion.identity);

            Color color = new(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
            cubeView.Init(this, scale, separationChance, color);

            return cubeView;
        }
    }
}
