using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonSpawner : MonoBehaviour
{

    [SerializeField] private Balloon _ballonPrefab;
    [SerializeField] private float _spawnRate = .5f;



    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    private void OnEnable() {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            Vector3 _spawnPosition = new Vector3(Random.Range(-2.5f, 2.5f), transform.position.y, 0);
            yield return new WaitForSeconds(_spawnRate);
            Instantiate(_ballonPrefab, _spawnPosition, Quaternion.identity, this.transform);
        }
    }
}
