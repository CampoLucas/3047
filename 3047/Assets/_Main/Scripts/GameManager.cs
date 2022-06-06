using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Player _player;
    //Score
    public Action<float> OnScoreChange;
    private float currentScore = 0f;
    public float scoreMultiplier = 1f;
    public Action<float> OnMultiplierChange;
    
    //GameTime
    public float currentGameTime=0f;
    public float MaxLevelGameTime = 9999f;
    public string currentLevel;
    public Transform bullets; //para no llenar la hierarchy de bullets y no crear un nuevo gameobject
                              //para guardarlo por arma y por enemy
    public Transform sinebullets;
    public void Start()
    {
        currentLevel = SceneManager.GetActiveScene().name;
        DontDestroyOnLoad(gameObject);
        OnScoreChange?.Invoke(currentScore);
    }
    
    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Update()
    {
        currentGameTime += Time.deltaTime;
        if (currentGameTime >= MaxLevelGameTime)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        //TODO
        //play death animation
        //show game over screen/scene/UIoverlay
        //show score
        
    }

    public void GameCompleted()
    {
        //TODO
        //play victory animations
        //show victory screen/scene/UIoverlay
        //show score
    }
    public void AddScore(float points)
    {
        currentScore += points * scoreMultiplier;
        OnScoreChange?.Invoke(currentScore);
    }    
    public void AddMultiplier(float multiplier)
    {
        scoreMultiplier += multiplier ;
        OnMultiplierChange?.Invoke(scoreMultiplier);
    }
    public void SubstractScore(float points)
    {
        currentScore -= points;
        OnScoreChange?.Invoke(currentScore);
    }
    public void ResetLevelValues()
    {
        currentGameTime = 0f;
        currentScore = 0f;
        scoreMultiplier = 1f;
        OnScoreChange?.Invoke(currentScore);
    }

    public void LoadNextLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
        currentLevel = levelName;
        ResetLevelValues();
    }
}
