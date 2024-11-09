using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float _horizontal;

    public int jumpForce;
    public SpriteRenderer spritePlayer;

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

        Debug.Log(rb.linearVelocityX);
    }

    void Jump()
    {
        rb.AddForceY(jumpForce, ForceMode2D.Impulse);
    }

    void Walk()
    {
        if (rb.linearVelocityX < 0)
        {
            spritePlayer.flipX = false;
        }

        if (rb.linearVelocityX > 0) 
        {
            spritePlayer.flipX = true;
        }

        if (rb.linearVelocityX != 0)
        {
            animator.SetBool("walk", true);
        }

        if (rb.linearVelocityX == 0)
        {
            animator.SetBool("walk", false);
        }
    }
}
