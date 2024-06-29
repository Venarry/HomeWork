using UnityEngine;

namespace RainOfCube
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private CubeSpawner _cubeSpawner;
        [SerializeField] private BombSpawnHandler _bombSpawnHandler;
        [SerializeField] private ObjectsCountShower _objectsCountShower;
        [SerializeField] private Transform _platform;

        private void Awake()
        {
            CubeFactory cubeFactory = new();
            BombFactory bombFactory = new();

            float spawnRange = Mathf.Min(_platform.localScale.x, _platform.localScale.z);
            float spawnDelay = 0.5f;

            _bombSpawnHandler.Init(bombFactory);
            _objectsCountShower.Init(cubeFactory, bombFactory);

            _cubeSpawner.Init(cubeFactory, spawnRange / 2, spawnDelay);
            _cubeSpawner.Enable();
        }
    }
}
