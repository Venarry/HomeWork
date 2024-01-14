using UnityEngine;

public class SizeScaler : MonoBehaviour
{
    [SerializeField] private Vector3 _scaleFactor = Vector3.one;
    [SerializeField] private float _changeDirectionTime = 1;

    private int _direction = 1;
    private float _timer;

    private void Update()
    {
        transform.localScale += _direction * Time.deltaTime * _scaleFactor;

        _timer += Time.deltaTime;

        if(_timer >= _changeDirectionTime)
        {
            _direction *= -1;
            _timer = 0;
        }
    }
}
