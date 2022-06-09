using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class HUD : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _multiplier;
    [SerializeField] private TextMeshProUGUI _gameTime;

    private void Start()
    {
        GameManager.instance.OnScoreChange += OnScoreChangeListener;
        GameManager.instance.OnMultiplierChange += OnMultiplerChangeListener;
    }

    private void Update()
    {
        _gameTime.text = "Time: " + Mathf.Round(GameManager.instance.currentGameTime*10f)/10f;
    }

    void OnScoreChangeListener(float score)
    {
        _scoreText.text ="Score " + score;
    }   
    void OnMultiplerChangeListener(float Multiplier)
    {
        _multiplier.text =Multiplier+"X";
    }
}
