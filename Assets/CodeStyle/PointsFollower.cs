using UnityEngine;

public class PointsFollower : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _pointsParent;

    private Transform[] _points;
    private Transform _activePoint;
    private int _activePointIndex;

    private void Start()
    {
        _points = new Transform[_pointsParent.childCount];

        for (int i = 0; i < _pointsParent.childCount; i++)
        {
            _points[i] = _pointsParent.GetChild(i);
        }
    }

    private void Update()
    {
        _activePoint = _points[_activePointIndex];

        transform.position = Vector3.MoveTowards(
            transform.position,
            _activePoint.position,
            _speed * Time.deltaTime);

        if (transform.position == _activePoint.position)
        {
            GoToNextPoint();
            RotateTo(_activePoint);
        }
    }

    private void GoToNextPoint()
    {
        _activePointIndex++;

        if (_activePointIndex == _points.Length)
            _activePointIndex = 0;

        _activePoint = _points[_activePointIndex];
    }

    private void RotateTo(Transform target)
    {
        transform.forward = target.position - transform.position;
    }
}