using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _multiplier;

    private void Start()
    {
        GameManager.instance.OnScoreChange += OnScoreChangeListener;
        GameManager.instance.OnMultiplierChange += OnMultiplerChangeListener;
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
