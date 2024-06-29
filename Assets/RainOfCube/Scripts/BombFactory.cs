using UnityEngine;

namespace RainOfCube
{
    public class BombFactory : ObjectPoolBehaviour<Bomb>
    {
        private readonly Bomb _prefab = Resources.Load<Bomb>(PrefabsPath.BombInRain);

        public Bomb Create(Vector3 position)
        {
            Bomb bomb = CreatePoolObject(position);

            return bomb;
        }

        protected override Bomb GetPrefab() => _prefab;
    }
}
