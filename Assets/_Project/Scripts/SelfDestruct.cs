using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    public void OnGameStart()
    {
        Destroy(gameObject);
    }
}
