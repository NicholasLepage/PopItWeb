using System.Collections;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    [SerializeField] private GameObject _balloonVisuals;

    [SerializeField] private AudioClip _badBalloonPopSound;
    [SerializeField] private Color[] _colors;

    private bool _isBadBalloon;
    private int _balloonValue;
    private float _speed = 1f;

    private AudioSource _audioSource;
    private MeshRenderer _balloonMeshRenderer;
    private CapsuleCollider _capsuleCollider;


    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _capsuleCollider = GetComponent<CapsuleCollider>();
        _balloonMeshRenderer = _balloonVisuals.GetComponent<MeshRenderer>();

        SetupBalloon();
    }

    // Update is called once per frame
    void Update()
    {
        FloatUpwards();
    }

    void SetupBalloon() {
        if (Random.Range(0, 5) == 0) {
            _isBadBalloon = true;
            _audioSource.clip = _badBalloonPopSound;
        }
        _speed = Random.Range(1f, 3f);

        _balloonMeshRenderer.material.color = _isBadBalloon ? Color.red : _colors[Random.Range(0, _colors.Length)];

        _balloonValue = _isBadBalloon ? -1 : 1;

        _balloonVisuals.SetActive(true);
    }


    private void FloatUpwards()
    {
        transform.position += Vector3.up * _speed * Time.deltaTime;
    }

    private void OnMouseDown()
    {
        Die();
    }

    private void Die()
    {
        GameManager.Instance.OnBalloonPopped.Invoke(_balloonValue);
        _audioSource.Play();
        _balloonVisuals.SetActive(false);
        _capsuleCollider.enabled = false;

        Destroy(gameObject, 0.5f);
    }

    public void CleanScreen() {
        _balloonVisuals.SetActive(false);
    }
}
