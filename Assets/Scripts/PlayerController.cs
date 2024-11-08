using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float _horizontal;

    public int jumpForce;

    Animator animator;
    Rigidbody2D rb;


    [SerializeField]
    float _speedPlayer;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Time.timeScale == 0)
        {
            return;
        }

        _horizontal = Input.GetAxis("Horizontal");
        rb.linearVelocityX = _horizontal * _speedPlayer;

        Walk();

        if (Input.GetKeyDown(KeyCode.W))
        {
            Jump();
        }
    }

    void Jump()
    {
        rb.AddForceY(jumpForce, ForceMode2D.Impulse);
    }

    void Walk()
    {
        if (rb.linearVelocityX != 0)
        {
            animator.SetBool("Walk", true);
        }

        if (rb.linearVelocityX == 0)
        {
            animator.SetBool("Walk", false);
        }
    }
}
