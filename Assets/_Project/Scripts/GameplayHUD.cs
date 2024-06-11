using System;
using TMPro;
using UnityEngine;

public class GameplayHUD : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _scoreText;

    // Start is called before the first frame update
    void Start()
    {
        UpdateScoreText();
        GameManager.Instance.OnBalloonPopped.AddListener(OnBalloonPopped);
        GameManager.Instance.OnGameStart.AddListener(() => UpdateScoreText());

        GameManager.Instance.OnGameOver.AddListener(OnGameOver);

        gameObject.SetActive(false);
    }

    private void OnGameOver()
    {
        gameObject.SetActive(false);
    }

    private void Update() {
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        _scoreText.text = $"Score: {GameManager.Instance.Score}";
    }

    private void OnBalloonPopped()
    {
        UpdateScoreText();
    }

}
