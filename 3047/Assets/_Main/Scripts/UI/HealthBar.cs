using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image Healthbar => _healthbar;
    [SerializeField] private Image _healthbar;

    public Damageable Damageable => _damageable;
    [SerializeField] private Damageable _damageable;

    void Start()
    {
        FillHealthbar();
    }

    public void FillHealthbar() => _healthbar.fillAmount = _damageable.GetLifePercentage();
}
