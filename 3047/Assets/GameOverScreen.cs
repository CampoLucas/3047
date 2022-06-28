using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _firstButtonText;
    [SerializeField] private bool _isWinner;

    private int _levelIndex;

    private void Start()
    {
        _scoreText.text = "Score: " + GameManager.instance.currentScore;
        _levelIndex = SceneManager.GetActiveScene().buildIndex;
        if (_isWinner && _levelIndex < SceneManager.sceneCountInBuildSettings)
        {
            _firstButtonText.text = "CONTINUE";
        }
        else if (_isWinner && _levelIndex >= SceneManager.sceneCountInBuildSettings || !_isWinner)
        {
            _firstButtonText.text = "RESTART";
        }
    }

    public void FirstButton()
    {
        if (_isWinner && _levelIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(_levelIndex + 1);
        }
        else
        {
            SceneManager.LoadScene(_levelIndex);
        }
    }

    public void MenuButton()
    {
        SceneManager.LoadScene(0);
    }
}
