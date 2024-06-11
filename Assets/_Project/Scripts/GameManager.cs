using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _balloonSpawner;

    public int TotalScore;

    public int Score = 0;

    public static GameManager Instance;

    public UnityEvent OnGameStart;
    public UnityEvent OnBalloonPopped;

    public UnityEvent OnGameOver;

    public enum GameState {
        MAINMENU,
        SHOP,
        PAUSE,
        GAME,
        GAMEOVER
    }

    public GameState CurrentGameState { get; private set; }


    private void Awake() {

        if(Instance == null) // If there is no instance already
        {
            DontDestroyOnLoad(gameObject); // Keep the GameObject, this component is attached to, across different scenes
            Instance = this;
        } else if(Instance != this) // If there is already an instance and it's not `this` instance
        {
            Destroy(gameObject); // Destroy the GameObject, this component is attached to
        }
        TotalScore = PlayerPrefs.GetInt("TotalScore", TotalScore);
    }

    private void Start() {
        CurrentGameState = GameState.MAINMENU;
    }        


    public void UpdateScore()
    {
        Score += 1;
    }

    public void StartGame() {
        OnGameStart.Invoke();

        CurrentGameState = GameState.GAME;

        Score = 0;

        print("Starting Game");
    }

    public void GameOver() {
        OnGameOver.Invoke();

        print("Game Over");

        _balloonSpawner.SetActive(false);

        _mainMenu.SetActive(true);

        CurrentGameState = GameState.GAMEOVER;

        TotalScore += Score;
        PlayerPrefs.SetInt("TotalScore", TotalScore);

    }
}
