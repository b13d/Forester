using UnityEngine;

public class Fog : MonoBehaviour
{
    int _direction = 0;
    Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _direction = Random.Range(1, 3);
    }


    private void FixedUpdate()
    {
        if (_direction == 1)
        {
            _rb.linearVelocityX = Random.Range(0f, -2f);
        }
        else
        {
            _rb.linearVelocityX = Random.Range(0f, 2f);
        }
    }
}
