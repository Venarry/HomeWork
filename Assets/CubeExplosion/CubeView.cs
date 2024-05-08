using UnityEngine;

namespace CubeExplosion
{
    [RequireComponent(typeof(Rigidbody))]
    public class CubeView : MonoBehaviour
    {
        private CubeFactory _cubeFactory;
        private Rigidbody _rigidbody;
        private float _separationChance;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void Init(CubeFactory cubeFactory, float scale, float separationChance, Color color)
        {
            _cubeFactory = cubeFactory;
            transform.localScale = new Vector3(scale, scale, scale);
            _separationChance = separationChance;

            GetComponent<MeshRenderer>().material.color = color;
        }

        public void Explose()
        {
            int minCubeCount = 2;
            int maxCubeCount = 6;

            int spawnedCubeCount = Random.Range(minCubeCount, maxCubeCount);

            if (MyMath.GetRandomResult(_separationChance))
            {
                float newSeparationChance = _separationChance / 2;

                for (int i = 0; i < spawnedCubeCount; i++)
                {
                    float minOffset = -0.2f;
                    float maxOffset = 0.2f;

                    float xOffset = Random.Range(minOffset, maxOffset);
                    float yOffset = Random.Range(0, maxOffset);

                    Vector3 spawnPoint = new(transform.position.x + xOffset, transform.position.y + yOffset, transform.position.z);
                    CubeView cube = _cubeFactory.Create(spawnPoint, transform.localScale.x / 2, newSeparationChance);

                    float explosionForceMultipy = 600;
                    float explosionRadius = 2;
                    cube.AddExplosionForce(transform.localScale.x * explosionForceMultipy, transform.position, explosionRadius);
                }
            }

            Destroy(gameObject);
        }

        private void AddExplosionForce(float force, Vector3 explosionPoint, float explosionRadius)
        {
            _rigidbody.AddExplosionForce(force, explosionPoint, explosionRadius);
        }
    }
}

