using UnityEngine;

public class AroundRotator : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed = 15;

    private void Update()
    {
        transform.Rotate(Vector3.up, _rotateSpeed * Time.deltaTime);
    }
}
