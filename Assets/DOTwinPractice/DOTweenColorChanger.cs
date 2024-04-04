using DG.Tweening;
using UnityEngine;

public class DOTweenColorChanger : DOTweenAction
{
    [SerializeField] private Color _endValue;
    [SerializeField] private MeshRenderer _meshRenderer;

    private void Start()
    {
        _meshRenderer.material
            .DOColor(_endValue, Duration).SetLoops(RepeatCount, LoopType);
    }
}