using UnityEngine;
using UnityEngine.Events;

public class LifeManager : MonoBehaviour
{
    // Singleton    
    public static LifeManager Instance;

    // Life
    public int Life;
    private int _initialLife = 3;

    // Events
    public UnityEvent OnLifeChanged;

    private AudioSource _audioSource;

    void Start()
    {
        if(Instance == null) // If there is no instance already
        {
            DontDestroyOnLoad(gameObject); // Keep the GameObject, this component is attached to, across different scenes
            Instance = this;
        } else if(Instance != this) // If there is already an instance and it's not `this` instance
        {
            Destroy(gameObject); // Destroy the GameObject, this component is attached to
        }

        _audioSource = GetComponent<AudioSource>();

        ResetLife();
    }

    public void GainLife(int amount = 1) {
        Life += amount;
        OnLifeChanged.Invoke();
    }

    public void LoseLife(int amount = 1) {
        Life -= amount;
        OnLifeChanged.Invoke();

        if (Life == 0) {
            GameManager.Instance.GameOver();
        }
    }

    public void ResetLife() {
        Life = _initialLife;
        OnLifeChanged.Invoke();
    }
}
