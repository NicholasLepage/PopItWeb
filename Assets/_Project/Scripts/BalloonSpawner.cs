using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonSpawner : MonoBehaviour
{

    [SerializeField] private Balloon _ballonPrefab;

    [SerializeField] private GameObject _balloonCollection;

    [SerializeField] private float _easySpawnRate = .5f;
    [SerializeField] private float _mediumSpawnRate = .3f;
    [SerializeField] private float _hardSpawnRate = .1f;


    private float _spawnRate = .5f;

    public enum DifficultyLevel {
        EASY,
        MEDIUM,
        HARD
    }

    private DifficultyLevel _currentDifficultyLevel { get; set; }


    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    private void OnEnable() {
        SetSpawnRate();
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            Vector3 _spawnPosition = new Vector3(Random.Range(-2.5f, 2.5f), transform.position.y, Random.Range(-2.5f, 2.5f));
            yield return new WaitForSeconds(_spawnRate);
            Instantiate(_ballonPrefab, _spawnPosition, Quaternion.identity, _balloonCollection.transform);
        }
    }

    public void SetDifficultyLevel(string newDifficultyLevel) {
        switch (newDifficultyLevel) {
            case "EASY":
                _currentDifficultyLevel = DifficultyLevel.EASY;
                break;
            case "MEDIUM":
                _currentDifficultyLevel = DifficultyLevel.MEDIUM;
                break;
            case "HARD":
                _currentDifficultyLevel = DifficultyLevel.HARD;
                break;
            default:
                _currentDifficultyLevel = DifficultyLevel.MEDIUM;
                break;
        }
    }

    public DifficultyLevel GetDifficultyLevel() {
        return _currentDifficultyLevel;
    }

    private void SetSpawnRate()
    {
        switch (_currentDifficultyLevel)
        {
            case DifficultyLevel.EASY:
                _spawnRate = _easySpawnRate;
                break;
            case DifficultyLevel.MEDIUM:
                _spawnRate = _mediumSpawnRate;
                break;
            case DifficultyLevel.HARD:
                _spawnRate = _hardSpawnRate;
                break;
            default:
                _spawnRate = _mediumSpawnRate;
                break;
        }
    }
}
