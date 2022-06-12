using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Player _player;
    public HUD _HUD;
    public GameObject HUD_Screen;
    [Header("Score")]
    public Action<float> OnScoreChange;
    public float currentScore = 0f;
    public float scoreMultiplier = 1f;
    public Action<float> OnMultiplierChange;
    
    [Header("Game_Time")]
    public float currentGameTime=0f;
    public float MaxLevelGameTime = 9999f;
    public UnityEvent OnLevelReset = new UnityEvent();

    [Header("Game_Over_Screen")] 
    [SerializeField] private GameObject GameOverScreen;    
    [Header("Victory_Screen")] 
    [SerializeField] private GameObject Victory_Screen;
    
    public string currentLevel;
    public GameObject bullets; //para no llenar la hierarchy de bullets y no crear un nuevo gameobject
                              //para guardarlo por arma y por enemy
    //TODO POOLS globales por cada tipo de bala
    public void Start()
    {
        bullets = new GameObject()
        {
            name = "Bullets"
        };
        currentLevel = SceneManager.GetActiveScene().name;
        DontDestroyOnLoad(gameObject);
        OnScoreChange?.Invoke(currentScore);
        OnMultiplierChange?.Invoke(scoreMultiplier);
        GameOverScreen.SetActive(false);
        Victory_Screen.SetActive(false);
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
        HUD_Screen.SetActive(false);
        GameOverScreen.SetActive(true);
        //play death animation
    }

    public void GameCompleted() //llamar al matar a un boss
    {
        //TODO
        HUD_Screen.SetActive(false);
        Victory_Screen.SetActive(true);
        //play victory animations
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

    public void ResetMultiplier()
    {
        scoreMultiplier = 1;
        OnMultiplierChange?.Invoke(scoreMultiplier);
    }

    public void AddMultiplierCounter(float num)
    {
        _HUD.AddMultiplierBar(num);
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
        OnLevelReset.Invoke();
    }

    public void LoadNextLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
        currentLevel = levelName;
        ResetLevelValues();
    }
}
