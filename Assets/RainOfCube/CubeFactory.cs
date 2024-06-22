using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RainOfCube
{
    public class CubeFactory : IObjectPool<Cube>
    {
        private readonly Cube _prefab = Resources.Load<Cube>(PrefabsPath.CubeInRain);
        private readonly List<Cube> _cubes = new();

        public Cube Create(Vector3 spawnPoint)
        {
            Cube cube = _cubes.FirstOrDefault(currentCube => currentCube.isActiveAndEnabled == false);

            if(cube == null)
            {
                cube = Object.Instantiate(_prefab, spawnPoint, Quaternion.identity);
                cube.Init(this);
                _cubes.Add(cube);
            }
            else
            {
                cube.gameObject.SetActive(true);
                cube.Respawn(spawnPoint, Quaternion.identity);
            }

            return cube;
        }

        public void Despawn(Cube target)
        {
            target.gameObject.SetActive(false);
        }
    }
}
