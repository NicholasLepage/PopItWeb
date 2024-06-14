using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameplayHUD : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _scoreText;

    [SerializeField] private Image _heart1, _heart2, _heart3;

    // Start is called before the first frame update
    void Start()
    {
        // Reset score UI to 0
        UpdateScoreText();

        GameManager.Instance.OnGameOver.AddListener(OnGameOver);
        GameManager.Instance.OnBalloonPopped.AddListener(OnBalloonPopped);

        ScoreManager.Instance.OnScoreChanged.AddListener(UpdateScoreText);

        LifeManager.Instance.OnLifeChanged.AddListener(UpdateLifeUI);

        gameObject.SetActive(false);
    }

    private void UpdateLifeUI()
    {
        if (LifeManager.Instance.Life == 3){
            _heart1.gameObject.SetActive(true);
            _heart2.gameObject.SetActive(true);
            _heart3.gameObject.SetActive(true);
        } else if (LifeManager.Instance.Life == 2){
            _heart1.gameObject.SetActive(true);
            _heart2.gameObject.SetActive(true);
            _heart3.gameObject.SetActive(false);
        } else if (LifeManager.Instance.Life == 1){
            _heart1.gameObject.SetActive(true);
            _heart2.gameObject.SetActive(false);
            _heart3.gameObject.SetActive(false);
        } else if (LifeManager.Instance.Life == 0){
            _heart1.gameObject.SetActive(false);
            _heart2.gameObject.SetActive(false);
            _heart3.gameObject.SetActive(false);
        }
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
