using UnityEngine;

namespace CubeExplosion
{
    public class CubeFactory
    {
        private readonly Cube _prefab = Resources.Load<Cube>(PrefabsPath.ExplosionCube);

        public Cube Create(Vector3 position, float scale, float separationChance)
        {
            Cube cubeView = Object.Instantiate(_prefab, position, Quaternion.identity);

            Color color = new(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
            cubeView.Init(this, scale, separationChance, color);

            return cubeView;
        }
    }
}
