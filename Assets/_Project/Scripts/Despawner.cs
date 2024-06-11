using UnityEngine;

public class Despawner : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        Destroy(other.gameObject);
    }
}
