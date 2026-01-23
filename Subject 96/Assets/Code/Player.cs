using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [Header("Floats")]
    public float speed = 6f;
    public float Ladderspeed = 3f;
    private float horizontal;
    private float vertical;
    public float jumpingPower = 12f;
    public float vaultDuration = 3f;
    public float DeadForce = 10f;
    private Transform ThingToHide;
    public GameObject body;

    [Header("Components")]
    public Rigidbody2D rb2d;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer, VaultLayer;
    [SerializeField] private Transform ceilingCheck;
    [SerializeField] private LayerMask HidingSpotLayer;

    [Header("Bools")]
    private bool isFacingRight = true;
    private bool canMove = true;
    private bool isLadder;
    private bool isClimbing;
    private bool dead = false;

    bool isCrouching = false;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private bool canStand()
    {
        return !Physics2D.OverlapCircle(ceilingCheck.position, 0.2f, groundLayer | VaultLayer);
    }

    private void Update()
    {
        if (dead) canMove = false;

        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if (dead) return;

        if (Input.GetButtonDown("Jump") && isGrounded() && !isCrouching)
        {
            rb2d.linearVelocity = new Vector2(rb2d.linearVelocity.x, jumpingPower);
        }

        if (Input.GetKeyDown(KeyCode.C) && isGrounded())
        {
            Crounch();
            isCrouching = true;
        }

        if (isCrouching && !Input.GetKey(KeyCode.C) && canStand())
        {
            StopCrounching();
            isCrouching = false;
        }


        if (isLadder && Mathf.Abs(vertical) > 0.1f)
        {
            isClimbing = true;
            speed = 3f;
        }
        else
        {
            isClimbing = false;
            speed = 6f;
        }

       

        Flip();
    }


    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private bool onLadder()
    {
        return isLadder;
    }

    void FixedUpdate()
    {
        if ((canMove && isGrounded()) || onLadder())
        {
            rb2d.linearVelocity = new Vector2(horizontal * speed, rb2d.linearVelocity.y);
        }

        if (isClimbing)
        {
            rb2d.gravityScale = 0f;
            rb2d.linearVelocity = new Vector2(rb2d.linearVelocity.x, vertical * Ladderspeed);
        }
        else
        {
            rb2d.gravityScale = 4f;
        }
    }

    private void Flip()
    {
        if (isGrounded() || onLadder())
        {
            if ((isFacingRight && horizontal < 0f) || (!isFacingRight && horizontal > 0f))
            {
                isFacingRight = !isFacingRight;
                Vector3 localScale = transform.localScale;
                localScale.x *= -1f;
                transform.localScale = localScale;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = true;
        }
        else if (collision.CompareTag("Restart"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = false;
            isClimbing = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        float force = collision.relativeVelocity.magnitude;
        Debug.Log("Force " + force);
        if(force > DeadForce)
        {
            Dead();
        }
    }

    void Crounch()
    {
        body.transform.localScale = new Vector2(1f, 1f);
    }

    void StopCrounching()
    {
        body.transform.localScale = new Vector2(1f, 1.5f);
    }

    void Dead()
    {
        dead = true;
        rb2d.AddTorque(50f);
        rb2d.constraints = RigidbodyConstraints2D.None;
        Debug.Log("Dead");
    }
}
