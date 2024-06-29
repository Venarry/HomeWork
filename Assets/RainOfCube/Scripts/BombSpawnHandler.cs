using System;
using UnityEngine;

namespace RainOfCube
{
    public class BombSpawnHandler : MonoBehaviour
    {
        [SerializeField] private CubeSpawner _cubeSpawner;
        private BombFactory _bombFactory;

        public event Action Spawned;

        public void Init(BombFactory bombFactory)
        {
            _bombFactory = bombFactory;
        }

        private void OnEnable()
        {
            _cubeSpawner.Spawned += OnCubeSpawn;
        }

        private void OnDisable()
        {
            _cubeSpawner.Spawned -= OnCubeSpawn;
        }

        private void OnCubeSpawn(Cube cube)
        {
            cube.DestroyedByTime += OnCubeDestroy;
        }

        private void OnCubeDestroy(Cube cube, float explodeTime)
        {
            cube.DestroyedByTime -= OnCubeDestroy;
            Bomb bomb = _bombFactory.Create(cube.transform.position);
            bomb.Explode(explodeTime);

            Spawned?.Invoke();
        }
    }
}
