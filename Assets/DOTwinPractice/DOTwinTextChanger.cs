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

    private void Start()
    {
        _text.DOText(FirstText, _duration).OnComplete(ShowSecondText);
    }

    private void ShowSecondText()
    {
        _text.DOText(SecondText, _duration).SetRelative().OnComplete(ShowThirdText);
    }

    private void ShowThirdText()
    {
        _text.DOText(ThirdText, _duration, true, ScrambleMode.All);
    }
}
