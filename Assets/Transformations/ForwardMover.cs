using UnityEngine;

public class ForwardMover : MonoBehaviour
{
    [SerializeField] private float _speed = 1;

    private void Update()
    {
        transform.position += _speed * Time.deltaTime * transform.forward;
    }
}
