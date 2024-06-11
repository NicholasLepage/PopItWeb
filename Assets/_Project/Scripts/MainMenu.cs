using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainMenu : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _totalBalloonMenuText;
    [SerializeField] private TextMeshProUGUI _totalBalloonOverText;
    [SerializeField] private TextMeshProUGUI _scoreObtainedText;

    [SerializeField] private Canvas _mainMenuCanvas;
    [SerializeField] private Canvas _gameOverCanvas;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
        _mainMenuCanvas.gameObject.SetActive(true);
        _gameOverCanvas.gameObject.SetActive(false);

        _totalBalloonMenuText.text = $"Balloons: {GameManager.Instance.TotalScore}";
        GameManager.Instance.OnGameStart.AddListener(() => gameObject.SetActive(false));
    }

    public void GameOverMenu() {
        _mainMenuCanvas.gameObject.SetActive(false);
        _gameOverCanvas.gameObject.SetActive(true);
        _scoreObtainedText.text = $"+{GameManager.Instance.Score}";
        _totalBalloonOverText.text = $"Balloons: {GameManager.Instance.TotalScore}";
    }

    public void ReturnToMainMenu() {
        _mainMenuCanvas.gameObject.SetActive(true);
        _totalBalloonMenuText.text = $"Balloons: {GameManager.Instance.TotalScore}";
        _gameOverCanvas.gameObject.SetActive(false);
    }
}
