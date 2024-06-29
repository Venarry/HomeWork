using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RainOfCube
{
    public abstract class ObjectPoolBehaviour<T> where T : MonoBehaviour, IPoolObject<T>
    {
        private readonly List<T> _objects = new();

        public int ActiveObjectsCount => _objects.Where(c => c.isActiveAndEnabled).Count();

        public event Action ActiveObjectsChanged;

        protected T CreatePoolObject(Vector3 spawnPoint)
        {
            T foundedObject = _objects.FirstOrDefault(c => c.isActiveAndEnabled == false);

            if (foundedObject == null)
            {
                foundedObject = UnityEngine.Object.Instantiate(GetPrefab(), spawnPoint, Quaternion.identity);
                _objects.Add(foundedObject);
            }
            else
            {
                foundedObject.gameObject.SetActive(true);
                foundedObject.Respawn(spawnPoint, Quaternion.identity);
            }

            ActiveObjectsChanged?.Invoke();
            foundedObject.Destroyed += OnObjectDestroy;

            return foundedObject;
        }

        private void OnObjectDestroy(T target)
        {
            target.Destroyed -= OnObjectDestroy;
            target.gameObject.SetActive(false);
            ActiveObjectsChanged?.Invoke();
        }

        protected abstract T GetPrefab();
    }
}
