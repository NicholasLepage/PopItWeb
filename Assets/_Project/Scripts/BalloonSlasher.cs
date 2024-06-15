using TMPro;
using UnityEngine;

public class BalloonSlasher : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _slasherToggleText;
    [SerializeField] private Canvas _slasherCanvas;

    public bool _isSlasherOn = false;

    private void Start() {
        gameObject.SetActive(true);
        _slasherToggleText.text = _isSlasherOn ? "ON" : "OFF";
    }

    public void OnToggleSlasher() {
        _isSlasherOn = !_isSlasherOn;

        _slasherToggleText.text = _isSlasherOn ? "ON" : "OFF";
    }

    public void OnGameStart() {
        gameObject.SetActive(false);
    }

    public void OnGameOver() {
        gameObject.SetActive(true);
        _slasherCanvas.gameObject.SetActive(true);
    }
}
