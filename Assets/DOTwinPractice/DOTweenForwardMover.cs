using DG.Tweening;
using UnityEngine;

public class DOTweenForwardMover : DOTweenAction
{
    [SerializeField] private Vector3 _endValue;

    private void Start()
    {
        transform.DOMove(_endValue, Duration).SetLoops(RepeatCount, LoopType);
    }
}
