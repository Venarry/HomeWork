using UnityEngine;

namespace CubeExplosion
{
    public interface ICubeFactory
    {
        public Cube Create(Vector3 position, float scale, float separationChance);
    }
}

