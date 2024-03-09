using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BulletSpawner : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Bullet _prefab;
    [SerializeField] private float _speed;
    [SerializeField] private float _shootCooldown;

    private Rigidbody _rigidbody;
    private WaitForSeconds _waitForSeconds;
    private bool _isWork;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _waitForSeconds = new WaitForSeconds(_shootCooldown);
        StartCoroutine(Shoot());
    }

    public void Disable()
    {
        _isWork = false;
    }

    private IEnumerator Shoot()
    {
        _isWork = true;

        while (_isWork)
        {
            Vector3 direction = (_target.position - transform.position).normalized;
            Instantiate(_prefab, transform.position + direction, Quaternion.identity);

            _rigidbody.transform.up = direction;
            _rigidbody.velocity = direction * _speed;

            yield return _waitForSeconds;
        }
    }
}

public class Bullet : MonoBehaviour
{
}