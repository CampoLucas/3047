using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _multiplierNum;
    [SerializeField] private TextMeshProUGUI _gameTime;
    [SerializeField] private Image _multiplierBar;
    [SerializeField, Range(0, 1)] private float normalMultiplierSpeed = 0.02f;
    private float _multiplierBarSpeed;
    private void Start()
    {
        GameManager.instance.OnScoreChange += OnScoreChangeListener;
        GameManager.instance.OnMultiplierChange += OnMultiplerChangeListener;
        
    }

    private void Update()
    {
        _gameTime.text = "" + Mathf.Round(GameManager.instance.currentGameTime*10f) / 10f;
        SubtractMultiplierBar();
        _multiplierBarSpeed = normalMultiplierSpeed * GameManager.instance.scoreMultiplier;
    }
    void SubtractMultiplierBar()
    {
        if (_multiplierBar.fillAmount <= 0)
        {
            _multiplierBar.fillAmount = 0;
            GameManager.instance.ResetMultiplier();
        }
        else
        {
            _multiplierBar.fillAmount -= _multiplierBarSpeed * Time.deltaTime;
        }
    }

    public void AddMultiplierBar(float num)
    {
        if (num > 1f) num = 1f;
        _multiplierBar.fillAmount += num;
        if (_multiplierBar.fillAmount >= 1)
        {
            GameManager.instance.AddMultiplier(1);
            _multiplierBar.fillAmount = 0.5f;
        }
    }

    public void ResetMultiplierBar()
    {
        _multiplierBar.fillAmount = 0f;
    }
    void OnScoreChangeListener(float score)
    {
        _scoreText.text = "Score " + score;
    }   
    void OnMultiplerChangeListener(float Multiplier)
    {
        _multiplierNum.text = Multiplier + "X";
    }
}
