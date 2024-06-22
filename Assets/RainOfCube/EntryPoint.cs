using UnityEngine;

namespace RainOfCube
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private CubeSpawner _cubeSpawner;
        [SerializeField] private Transform _platform;

        private void Awake()
        {
            CubeFactory cubeFactory = new();

            float spawnRange = Mathf.Min(_platform.localScale.x, _platform.localScale.z);
            float spawnDelay = 0.5f;

            _cubeSpawner.Init(cubeFactory, spawnRange / 2, spawnDelay);
            _cubeSpawner.Enable();
        }
    }
}
