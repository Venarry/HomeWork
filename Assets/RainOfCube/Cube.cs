using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

namespace RainOfCube
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(MeshRenderer))]
    public class Cube : MonoBehaviour
    {
        private const float MinDestroyTime = 2f;
        private const float MaxDestroyTime = 5f;

        private IObjectPool<Cube> _cubeSpawner;
        private Rigidbody _rigidbody;
        private MeshRenderer _meshRenderer;
        private Coroutine _activeDespawning;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _meshRenderer = GetComponent<MeshRenderer>();
        }

        public void Init(IObjectPool<Cube> cubeSpawner)
        {
            _cubeSpawner = cubeSpawner;
        }

        public void Respawn(Vector3 position, Quaternion rotation)
        {
            transform.SetPositionAndRotation(position, rotation);
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.angularVelocity = Vector3.zero;
            _meshRenderer.material.color = Color.white;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out Platform platform))
            {
                if(_activeDespawning == null)
                {
                    WaitForSeconds waitForSeconds = new(Random.Range(MinDestroyTime, MaxDestroyTime));
                    _activeDespawning = StartCoroutine(Despawning(waitForSeconds));
                }
            }
        }

        private IEnumerator Despawning(WaitForSeconds waitForSeconds)
        {
            _meshRenderer.material.color = Color.red;

            yield return waitForSeconds;

            _activeDespawning = null;
            _cubeSpawner.Despawn(this);
        }
    }
}


