using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    void Start()
    {
        GameManager.Instance.OnGameStart.AddListener(() => Destroy(gameObject));
    }
}
