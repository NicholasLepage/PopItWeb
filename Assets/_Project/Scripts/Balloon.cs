using System.Collections;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;
    [SerializeField] private GameObject _balloonVisuals;

    [SerializeField] private Color[] _colors;

    private AudioSource _audioSource;
    private MeshRenderer _balloonMeshRenderer;
    private CapsuleCollider _capsuleCollider2D;


    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _capsuleCollider2D = GetComponent<CapsuleCollider>();
        _balloonMeshRenderer = _balloonVisuals.GetComponent<MeshRenderer>();
        _balloonMeshRenderer.material.color = _colors[Random.Range(0, _colors.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        FloatUpwards();
    }

    private void FloatUpwards()
    {
        transform.position += Vector3.up * _speed * Time.deltaTime;
    }

    private void OnMouseDown()
    {
        StartCoroutine(Die());
    }

    private IEnumerator Die()
    {
        GameManager.Instance.OnBalloonPopped.Invoke();
        _audioSource.Play();
        _balloonVisuals.SetActive(false);
        _capsuleCollider2D.enabled = false;

        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
