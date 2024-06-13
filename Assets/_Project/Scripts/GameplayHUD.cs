using TMPro;
using UnityEngine;

public class GameplayHUD : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _scoreText;

    // Start is called before the first frame update
    void Start()
    {
        // Reset score UI to 0
        UpdateScoreText();

        GameManager.Instance.OnGameOver.AddListener(OnGameOver);
        GameManager.Instance.OnBalloonPopped.AddListener(OnBalloonPopped);

        ScoreManager.Instance.OnScoreChanged.AddListener(UpdateScoreText);

        gameObject.SetActive(false);
    }

    private void OnGameOver()
    {
        gameObject.SetActive(false);
    }



    private void UpdateScoreText()
    {
        _scoreText.text = $"Score: {ScoreManager.Instance.Score}";
    }

    private void OnBalloonPopped(int score)
    {
        UpdateScoreText();
    }

}
