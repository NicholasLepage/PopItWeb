using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _totalBalloonMenuText;
    [SerializeField] private TextMeshProUGUI _scoreObtainedText;


    [SerializeField] private Canvas _mainMenuCanvas;
    [SerializeField] private Button _mysteryButton;

    private int _mysteryCost = 1000;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
        _mainMenuCanvas.gameObject.SetActive(true);

        _totalBalloonMenuText.text = $"Balloons: {ScoreManager.Instance.TotalScore}";
    }

    public void GameOverMenu() {
        _mainMenuCanvas.gameObject.SetActive(true);
        
        _scoreObtainedText.enabled = true;
        _scoreObtainedText.text = $"+{ScoreManager.Instance.Score}";

        _totalBalloonMenuText.text = $"Balloons: {ScoreManager.Instance.TotalScore}";

        // Check Mystery Button Progress
        if (ScoreManager.Instance.TotalScore > _mysteryCost) {
            _mysteryButton.interactable = true;
        } else {
            _mysteryButton.interactable = false;
        }
    }

    public void OnGameStart() {
        gameObject.SetActive(false);
    }

    public void OnMysteryButton() {
        if (ScoreManager.Instance.TotalScore >= _mysteryCost) {
            // Pay up the Balloon Price
            ScoreManager.Instance.TotalScore -= _mysteryCost;
        }
    }
}
