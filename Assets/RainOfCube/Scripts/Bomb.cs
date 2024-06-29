using System;
using System.Collections;
using UnityEngine;

namespace RainOfCube
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(MeshRenderer))]
    public class Bomb : PoolObjectBehaviour, IPoolObject<Bomb>
    {
        public event Action<Bomb> Destroyed;

        public void Explode(float delay)
        {
            StartCoroutine(Exploding(delay));
        }

        private IEnumerator Exploding(float delay)
        {
            float timer = 0;

            while (timer < delay)
            {
                float alphaProgress = 1 - timer / delay;
                Color targetColor = new(0, 0, 0, alphaProgress);
                MeshRenderer.material.color = targetColor;

                timer += Time.deltaTime;

                yield return null;
            }

            AddExplosionForce();

            Destroyed?.Invoke(this);
        }

        private void AddExplosionForce()
        {
            float explosionRadius = 8f;
            float explosionForce = 800f;
            var colliders = Physics.OverlapSphere(transform.position, explosionRadius);

            foreach (Collider collider in colliders)
            {
                if (collider.TryGetComponent(out Rigidbody rigidbody))
                {
                    rigidbody.AddExplosionForce(explosionForce, transform.position, explosionRadius);
                }
            }
        }
    }
}
