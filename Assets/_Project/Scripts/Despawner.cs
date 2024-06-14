using UnityEngine;

public class Despawner : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Balloon") {
            LifeManager.Instance.LoseLife();
        }
        Destroy(other.gameObject);
    }
}
