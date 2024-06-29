using System;
using System.Collections;
using UnityEngine;

namespace RainOfCube
{
    public class CubeSpawner : MonoBehaviour
    {
        [SerializeField] private Transform _startPoint;

        private float _spawnRange;
        private float _spawnDelay;
        private WaitForSeconds _waitForSeconds;
        private Coroutine _activeSpawner;
        private CubeFactory _cubeFactory;

        public event Action<Cube> Spawned;

        public void Init(CubeFactory cubeFactory, float spawnRange, float spawnDelay)
        {
            if(spawnDelay < 0)
                spawnDelay = 0;

            _cubeFactory = cubeFactory;
            _spawnRange = spawnRange;
            _spawnDelay = spawnDelay;

            _waitForSeconds = new WaitForSeconds(_spawnDelay);
        }

        public void Enable() 
        {
            _activeSpawner = StartCoroutine(Spawning());
        }

        public void Disable() 
        {
            if(_activeSpawner != null)
            {
                StopCoroutine(_activeSpawner);
                _activeSpawner = null;
            }
        }

        private IEnumerator Spawning()
        {
            while (true)
            {
                float spawnPositionX = UnityEngine.Random.Range(-_spawnRange, _spawnRange);
                float spawnPositionZ = UnityEngine.Random.Range(-_spawnRange, _spawnRange);

                Vector3 spawnPoint = new(spawnPositionX, _startPoint.position.y, spawnPositionZ);
                Cube cube = _cubeFactory.Create(spawnPoint);
                Spawned?.Invoke(cube);

                yield return _waitForSeconds;
            }
        }
    }
}
