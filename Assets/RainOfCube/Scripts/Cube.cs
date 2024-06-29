using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

namespace RainOfCube
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(MeshRenderer))]
    public class Cube : PoolObjectBehaviour, IPoolObject<Cube>
    {
        private const float MinDestroyTime = 2f;
        private const float MaxDestroyTime = 5f;

        private Coroutine _activeDespawning;

        public event Action<Cube> Destroyed;
        public event Action<Cube, float> DestroyedByTime;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out Platform _))
            {
                if(_activeDespawning == null)
                {
                    float destroyTime = UnityEngine.Random.Range(MinDestroyTime, MaxDestroyTime);
                    WaitForSeconds waitForSeconds = new(destroyTime);
                    _activeDespawning = StartCoroutine(Despawning(waitForSeconds, destroyTime));
                }
            }
        }

        private IEnumerator Despawning(WaitForSeconds waitForSeconds, float destroyTime)
        {
            MeshRenderer.material.color = Color.red;

            yield return waitForSeconds;

            _activeDespawning = null;
            Destroyed?.Invoke(this);
            DestroyedByTime?.Invoke(this, destroyTime);
        }
    }
}


