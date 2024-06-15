using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _totalBalloonMenuText;
    [SerializeField] private TextMeshProUGUI _scoreObtainedText;
    [SerializeField] private Button _playButton;


    [SerializeField] private Canvas _mainMenuCanvas;
    [SerializeField] private Button _mysteryButton;

    [SerializeField] private GameObject _balloonSlasher;

    private int _mysteryCost = 1000;

    private float _replayDelay = 0.5f;

    private Animator _balloonSlasherAnimator;

    public bool BalloonSlasherObtained { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
        _mainMenuCanvas.gameObject.SetActive(true);

        _balloonSlasherAnimator = _balloonSlasher.GetComponent<Animator>();

        _totalBalloonMenuText.text = $"Balloons: {ScoreManager.Instance.TotalScore}";

        BalloonSlasherObtained = PlayerPrefs.GetInt("SlasherObtained", 0) == 1 ? true : false;
        _balloonSlasherAnimator.SetBool("AlreadyUnlocked", true);

        CheckMysteryButtonProgress();
    }

    public void GameOverMenu()
    {
        gameObject.SetActive(true);
        _mainMenuCanvas.gameObject.SetActive(true);
        StartCoroutine(ReplayDelay()); // Prevent accidental replay

        _scoreObtainedText.enabled = true;
        _scoreObtainedText.text = $"+{ScoreManager.Instance.Score}";

        SetTotalBalloonText();

        CheckMysteryButtonProgress();
    }

    private void CheckMysteryButtonProgress()
    {
        if (ScoreManager.Instance.TotalScore > _mysteryCost) _mysteryButton.interactable = true; else _mysteryButton.interactable = false;
        if (BalloonSlasherObtained) _mysteryButton.gameObject.SetActive(false);
    }

    private void SetTotalBalloonText() {
        _totalBalloonMenuText.text = $"Balloons: {ScoreManager.Instance.TotalScore}";
    }

    private IEnumerator ReplayDelay() {
        _playButton.interactable = false;
        yield return new WaitForSeconds(_replayDelay);
        _playButton.interactable = true;
    }

    public void OnGameStart() {
        gameObject.SetActive(false);
    }

    public void OnMysteryButton() {
        if (ScoreManager.Instance.TotalScore >= _mysteryCost) {
            // Pay up the Balloon Price
            // ScoreManager.Instance.UpdateTotalScore(-_mysteryCost);
            SetTotalBalloonText();

            GameManager.Instance.BalloonSlasherObtained = true;

            PlayerPrefs.SetInt("SlasherObtained", 1);
            PlayerPrefs.Save();

            _mysteryButton.gameObject.SetActive(false);
            _balloonSlasherAnimator.SetBool("BalloonSlasherAcquired", true);
        }
    }
}
