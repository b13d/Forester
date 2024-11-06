using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float _horizontal;
    float _vertical;

    Animator _animator;
    Rigidbody2D _rb;
    Stamina _stamina;

    [SerializeField]
    float _speedPlayer;

    private void Start()
    {
        _stamina = GetComponent<Stamina>();
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
    }

    public Stamina Stamina => _stamina;

    void Update()
    {
        if (Time.timeScale == 0)
        {
            return;
        }

        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");

        _rb.linearVelocity = new Vector2(_horizontal, _vertical) * _speedPlayer;

        Walk();
    }

    void Walk()
    {
        if (_rb.linearVelocityX != 0 || _rb.linearVelocityY != 0)
        {
            _animator.SetBool("Walk", true);
        }

        if (_rb.linearVelocityX == 0 && _rb.linearVelocityY == 0)
        {
            _animator.SetBool("Walk", false);
        }
    }
}
