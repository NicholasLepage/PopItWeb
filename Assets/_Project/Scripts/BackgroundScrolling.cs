using UnityEngine;

public class BackgroundScrolling : MonoBehaviour
{
    [SerializeField] private float _speed = -0.5f;

    private Vector3 _startPosition = new Vector3(-3f, -5.5f, 10f);

    // Update is called once per frame
    void Update()
    {
        Scroll();
    }

    private void Scroll()
    {
        transform.position += new Vector3(_speed, _speed, 0) * Time.deltaTime;
        if (transform.position.x <= -3.5f) {
            transform.position = _startPosition;
        }
    }
}
