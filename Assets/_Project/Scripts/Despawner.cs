using UnityEngine;

public class Despawner : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        print("3D");
        Destroy(other.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        print("2D");    
        Destroy(other.gameObject);
    }
}
