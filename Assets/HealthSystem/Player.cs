using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private HealthView _healthView;
    [SerializeField] private PlayerHealthView _playerHealthView;

    public void Init(HealthPresenter healthPresenter, TMP_Text healthLabel)
    {
        _healthView.Init(healthPresenter);
        _playerHealthView.Init(healthPresenter, healthLabel);
    }
}
