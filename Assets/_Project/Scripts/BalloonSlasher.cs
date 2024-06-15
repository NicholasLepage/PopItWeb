using TMPro;
using UnityEngine;

public class BalloonSlasher : MonoBehaviour
{

    [SerializeField] private GameObject _balloonSlasherMesh;
    [SerializeField] private TextMeshProUGUI _slasherToggleText;
    [SerializeField] private Canvas _slasherCanvas;

    [SerializeField] private GameObject _slasherAbility;

    public bool _isSlasherOn = false;

    private Vector3 _slashOffset = new Vector3(0, 0, 10f);

    private void Start() {
        gameObject.SetActive(true);
        _slasherToggleText.text = _isSlasherOn ? "ON" : "OFF";
    }

    private void Update() {
        if (_isSlasherOn && GameManager.Instance.CurrentGameState == GameManager.GameState.GAME) {
            if (Input.GetMouseButton(0)) {
                _slasherAbility.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + _slashOffset;
                _slasherAbility.SetActive(true);
            }
        }
    }


    public void OnToggleSlasher() {
        _isSlasherOn = !_isSlasherOn;

        _slasherToggleText.text = _isSlasherOn ? "ON" : "OFF";
    }

    public void OnGameStart() {
        _balloonSlasherMesh.SetActive(false);
        _slasherCanvas.gameObject.SetActive(false);
        
    }

    public void OnGameOver() {
        _balloonSlasherMesh.SetActive(true);
        _slasherCanvas.gameObject.SetActive(true);
    }
}
