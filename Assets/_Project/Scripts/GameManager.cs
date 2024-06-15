using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _balloonSpawner;

    [SerializeField] private GameObject _balloonCollection;

    public static GameManager Instance;

    // Events
    public UnityEvent OnGameStart;
    public UnityEvent<int> OnBalloonPopped;
    public UnityEvent OnGameOver;


    public bool BalloonSlasherObtained = false;
    public bool BalloonSlasherTurnedOn = false;

    public enum GameState {
        MAINMENU,
        SHOP,
        PAUSE,
        GAME,
        GAMEOVER
    }
    public GameState CurrentGameState { get; private set; }


    private void Start() {
        if(Instance == null) // If there is no instance already
        {
            DontDestroyOnLoad(gameObject); // Keep the GameObject, this component is attached to, across different scenes
            Instance = this;
        } else if(Instance != this) // If there is already an instance and it's not `this` instance
        {
            Destroy(gameObject); // Destroy the GameObject, this component is attached to
        }
        CurrentGameState = GameState.MAINMENU;

        BalloonSlasherObtained = PlayerPrefs.GetInt("SlasherObtained", 0) == 1 ? true : false;
    }        


    public void StartGame() {
        // Starting Game 📢
        OnGameStart.Invoke();
        CurrentGameState = GameState.GAME;
        print("Starting Game");
    }

    public void GameOver() {
        // Game Over 📢
        OnGameOver.Invoke();
        CurrentGameState = GameState.GAMEOVER;
        print("Game Over");

        _balloonSpawner.SetActive(false); // Ballloon Spawner's job

        foreach (Transform child in _balloonCollection.transform) {
            child.position = new Vector3(10f, 0, 0);
            child.tag = "Untagged";
        }

        _mainMenu.SetActive(true);
    }
    


}
