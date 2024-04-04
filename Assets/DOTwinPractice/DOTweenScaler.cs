using DG.Tweening;
using UnityEngine;

public class DOTweenScaler : DOTweenAction
{
    [SerializeField] private Vector3 _endValue;
    private void Start()
    {
        transform.DOScale(_endValue, Duration).SetLoops(RepeatCount, LoopType);
    }
}
