using System.Collections;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;
    [SerializeField] private GameObject _balloonVisuals;

    [SerializeField] private AudioClip _badBalloonPopSound;
    [SerializeField] private Color[] _colors;

    private bool _isBadBalloon;

    private AudioSource _audioSource;
    private MeshRenderer _balloonMeshRenderer;
    private CapsuleCollider _capsuleCollider2D;


    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _capsuleCollider2D = GetComponent<CapsuleCollider>();
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
        _balloonMeshRenderer.material.color = _isBadBalloon ? Color.red : _colors[Random.Range(0, _colors.Length)];
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
        GameManager.Instance.OnBalloonPopped.Invoke();
        _audioSource.Play();
        _balloonVisuals.SetActive(false);
        _capsuleCollider2D.enabled = false;

        Destroy(gameObject, 0.5f);
    }
}
