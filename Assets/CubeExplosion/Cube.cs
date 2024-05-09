using UnityEngine;

namespace CubeExplosion
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(MeshRenderer))]
    public class Cube : MonoBehaviour
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

        public void Explode()
        {
            int minCubeCount = 2;
            int maxCubeCount = 6;

            int spawnedCubeCount = Random.Range(minCubeCount, maxCubeCount);

            if (MyMath.GetRandomResult(_separationChance))
            {
                float newSeparationChance = _separationChance / 2;
                float minOffset = -0.2f;
                float maxOffset = 0.2f;

                for (int i = 0; i < spawnedCubeCount; i++)
                {
                    float xOffset = Random.Range(minOffset, maxOffset);
                    float yOffset = Random.Range(0, maxOffset);

                    Vector3 spawnPoint = new(transform.position.x + xOffset, transform.position.y + yOffset, transform.position.z);
                    Cube cube = _cubeFactory.Create(spawnPoint, transform.localScale.x / 2, newSeparationChance);

                    float explosionRadius = 2;
                    float baseExplodeStrength = 600;
                    cube.AddExplosionForce(transform.localScale.x * baseExplodeStrength, transform.position, explosionRadius);
                }
            }
            else
            {
                float baseExplodeRadius = 10f;
                float baseExplodeStrength = 1000;

                float targetExplodeRadius = baseExplodeRadius / transform.localScale.x;
                float targetExplodeStrength = baseExplodeStrength / transform.localScale.x;

                Collider[] colliders = Physics.OverlapSphere(transform.position, targetExplodeRadius);

                foreach (Collider collider in colliders)
                {
                    if(collider.TryGetComponent(out Cube cube))
                    {
                        cube.AddExplosionForce(targetExplodeStrength, transform.position, targetExplodeRadius);
                    }
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

