using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class DOTwinTextChanger : MonoBehaviour
{
    private const string FirstText = "First try";
    private const string SecondText = "Second try";
    private const string ThirdText = "Third try";

    [SerializeField] private Text _text;
    [SerializeField] private float _duration = 2f;

    private Tween _tween;

    private void Start()
    {
        _tween = _text.DOText(FirstText, _duration);
        _tween.onKill += OnFirstKill;
    }

    private void OnFirstKill()
    {
        _tween.onKill -= OnFirstKill;
        _tween = _text.DOText(SecondText, _duration).SetRelative();
        _tween.onKill += OnSecondKill;
    }

    private void OnSecondKill()
    {
        _tween.onKill -= OnSecondKill;
        _text.DOText(ThirdText, _duration, true, ScrambleMode.All);
    }
}
