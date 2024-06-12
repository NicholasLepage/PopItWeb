using UnityEngine;

public class Despawner : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Balloon") {
            GameManager.Instance.LoseLife();
        }
        Destroy(other.gameObject);
    }
}
