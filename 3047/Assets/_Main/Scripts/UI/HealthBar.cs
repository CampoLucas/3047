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

    public float whatever;
    private void Awake()
    {
        Damageable.OnLifeUpdate += FillHealthbar;
    }

    public void FillHealthbar(int currentlife)
    {
        _healthbar.fillAmount = (float)currentlife/_damageable.Stats.Life;
    }
}
