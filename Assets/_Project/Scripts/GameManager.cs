using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _balloonSpawner;

    [SerializeField] private GameObject _balloonCollection;

    public int TotalScore;

    public int Score = 0;

    public int Life = 3;

    public static GameManager Instance;

    public UnityEvent OnGameStart;
    public UnityEvent<int> OnBalloonPopped;

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


    public void UpdateScore(int balloonValue)
    {
        Score += balloonValue;
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
        CurrentGameState = GameState.GAMEOVER;

        _balloonSpawner.SetActive(false);

        foreach (Transform child in _balloonCollection.transform) {
            child.position = new Vector3(10f, 0, 0);
        }

        _mainMenu.SetActive(true);


        TotalScore += Score;
        PlayerPrefs.SetInt("TotalScore", TotalScore);

    }

    public void LoseLife() {
        Life -= 1;
        
        if (Life == 0) {
            GameOver();
        }
    }
}
