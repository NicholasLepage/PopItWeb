using UnityEngine;

public class SelfDes : MonoBehaviour
{
    void Start()
    {
        GameManager.Instance.OnGameStart.AddListener(() => Destroy(gameObject));
    }
}
