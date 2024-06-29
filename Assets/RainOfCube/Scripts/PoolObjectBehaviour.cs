using UnityEngine;

namespace RainOfCube
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(MeshRenderer))]
    public class PoolObjectBehaviour : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [field: SerializeField] protected MeshRenderer MeshRenderer;

        public void Respawn(Vector3 spawnPosition, Quaternion rotation)
        {
            transform.SetPositionAndRotation(spawnPosition, rotation);
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.angularVelocity = Vector3.zero;
            MeshRenderer.material.color = Color.white;
        }
    }
}
