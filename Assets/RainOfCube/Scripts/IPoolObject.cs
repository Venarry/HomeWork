using System;
using UnityEngine;

namespace RainOfCube
{
    public interface IPoolObject<T> where T : class
    {
        public event Action<T> Destroyed;
        public void Respawn(Vector3 spawnPosition, Quaternion rotation);
    }
}
