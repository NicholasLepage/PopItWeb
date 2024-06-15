using TMPro;
using UnityEngine;

public class BalloonSlasher : MonoBehaviour
{

    [SerializeField] private GameObject _balloonSlasherMesh;
    [SerializeField] private TextMeshProUGUI _slasherToggleText;
    [SerializeField] private Canvas _slasherCanvas;

    [SerializeField] private GameObject _slasherAbility;

    private CapsuleCollider _slasherCollider;
    private ParticleSystem _slasherParticle;

    public bool _isSlasherOn = false;

    private Vector3 _slashOffset = new Vector3(0, 0, 10f);

    private void Start() {
        gameObject.SetActive(true);
        _slasherCollider = _slasherAbility.GetComponent<CapsuleCollider>();
        _slasherParticle = _slasherAbility.GetComponentInChildren<ParticleSystem>();

        _slasherToggleText.text = _isSlasherOn ? "ON" : "OFF";

    }

    private void Update()
    {
        HandleSlasherAbility();
    }

    private void HandleSlasherAbility()
    {
        if (_isSlasherOn && GameManager.Instance.CurrentGameState == GameManager.GameState.GAME)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _slasherAbility.SetActive(true);
                _slasherCollider.enabled = true;
                _slasherParticle.Play();
            }
            if (Input.GetMouseButton(0))
            {
                _slasherAbility.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + _slashOffset;
            }
            if (Input.GetMouseButtonUp(0))
            {
                _slasherParticle.Stop();
                _slasherCollider.enabled = false;
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
        _slasherCanvas.enabled = false;
        
    }

    public void OnGameOver() {
        _balloonSlasherMesh.SetActive(true);
        _slasherCanvas.gameObject.SetActive(true);
        _slasherCanvas.enabled = true;
    }
}
