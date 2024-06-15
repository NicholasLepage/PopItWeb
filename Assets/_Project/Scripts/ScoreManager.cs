using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{

    public static ScoreManager Instance;

    public int TotalScore = 0;

    public int Score = 0;

    public UnityEvent OnScoreChanged;

    
    void Awake() {

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

    public void OnGameStart()
    {
        Score = 0;
        OnScoreChanged.Invoke();
    }

    public void UpdateScore(int balloonValue) {
        Score += balloonValue;
        if (Score < 0) Score = 0;

        // Score Changed 📢
        OnScoreChanged.Invoke();
    }

    public void UpdateTotalScore(int scoreValue) {
        TotalScore += scoreValue;
        PlayerPrefs.SetInt("TotalScore", TotalScore);
    }

    public void OnGameOver()
    {
        TotalScore += Score;
        PlayerPrefs.SetInt("TotalScore", TotalScore);
    }
}
