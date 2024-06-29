using TMPro;
using UnityEngine;

namespace RainOfCube
{
    public class ObjectsCountShower : MonoBehaviour
    {
        [SerializeField] private TMP_Text _allCubesCounter;
        [SerializeField] private TMP_Text _allBombesCounter;
        [SerializeField] private TMP_Text _activeObjectCounter;

        [SerializeField] private CubeSpawner _cubeSpawner;
        [SerializeField] private BombSpawnHandler _bombSpawnHandler;

        private CubeFactory _cubeFactory; 
        private BombFactory _bombFactory;
        private int _cubeCounter;
        private int _bombCounter;

        public void Init(CubeFactory cubeFactory, BombFactory bombFactory)
        {
            _cubeFactory = cubeFactory;
            _bombFactory = bombFactory;

            _cubeSpawner.Spawned += OnCubeSpawn;
            _bombSpawnHandler.Spawned += OnBombSpawn;

            _cubeFactory.ActiveObjectsChanged += OnActiveObjectChange;
            _bombFactory.ActiveObjectsChanged += OnActiveObjectChange;
        }

        private void OnDestroy()
        {
            _cubeSpawner.Spawned -= OnCubeSpawn;
            _bombSpawnHandler.Spawned -= OnBombSpawn;

            _cubeFactory.ActiveObjectsChanged -= OnActiveObjectChange;
            _bombFactory.ActiveObjectsChanged -= OnActiveObjectChange;
        }

        private void OnActiveObjectChange()
        {
            _activeObjectCounter.text = 
                (_cubeFactory.ActiveObjectsCount + _bombFactory.ActiveObjectsCount)
                .ToString();
        }

        private void OnCubeSpawn(Cube cube)
        {
            AddCount(ref _cubeCounter, _allCubesCounter);
        }

        private void OnBombSpawn()
        {
            AddCount(ref _bombCounter, _allBombesCounter);
        }

        private void AddCount(ref int counter, TMP_Text label)
        {
            counter++;
            label.text = counter.ToString();
        }
    }
}
