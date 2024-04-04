using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.UI;

public class DOTwinTextChanger : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private float _duration = 2f;

    private Tween _tween;

    private void Start()
    {
        _tween = _text.DOText("First try", _duration);
        _tween.onKill += OnFirstKill;
    }

    private void OnFirstKill()
    {
        _tween.onKill -= OnFirstKill;
        _tween = _text.DOText("Second try", _duration).SetRelative();
        _tween.onKill += OnSecondKill;
    }

    private void OnSecondKill()
    {
        _tween.onKill -= OnSecondKill;
        _text.DOText("Third try", _duration, true, ScrambleMode.All);
    }
}
