using DG.Tweening;
using UnityEngine;

public class DOTweenRotator : DOTweenAction
{
    [SerializeField] private Vector3 _endValue;

    private void Start()
    {
        transform.DORotate(_endValue, Duration).SetLoops(RepeatCount, LoopType);
    }
}
