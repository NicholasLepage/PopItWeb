using UnityEngine;

public class Despawner : MonoBehaviour
{
    private AudioSource _audioSource;

    private void Start() {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Balloon") {
            LifeManager.Instance.LoseLife();
            _audioSource.Play();
        }
        Destroy(other.gameObject);
    }
}
