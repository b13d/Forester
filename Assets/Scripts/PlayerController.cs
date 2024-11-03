using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float _horizontal;
    float _vertical;

    Animator _animator;
    Rigidbody2D _rb;

    [SerializeField]
    float _speedPlayer;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
    }

 


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
        Attack();
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

    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _animator.SetTrigger("AttackTree");
        }
    }
}
