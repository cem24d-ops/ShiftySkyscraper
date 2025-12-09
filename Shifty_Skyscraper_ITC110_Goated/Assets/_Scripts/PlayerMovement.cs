using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public KeyCode leftKey = KeyCode.LeftArrow;
    public KeyCode rightKey = KeyCode.RightArrow;
    public KeyCode jumpKey = KeyCode.UpArrow;
    public KeyCode interactKey = KeyCode.DownArrow;
    public KeyCode pauseKey = KeyCode.Space;
    public float moveSpeed = 10.0f;

    public float jumpForce = 500.0f;
    public RectTransform pauseMenuPanel;

    Rigidbody2D rb;

    public bool isGrounded = true;

    public bool shouldJump = false;
    public InteractionDetector interactionDetector;

     Animator animator;

    SpriteRenderer spriteRenderer;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        // get horizontal input
        if (Input.GetKey(leftKey))
        {
            rb.linearVelocity = new Vector2(-moveSpeed, rb.linearVelocity.y);
        }
        else if (Input.GetKey(rightKey))
        {
            rb.linearVelocity = new Vector2(moveSpeed, rb.linearVelocity.y);
        }
        else
        {
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
        }

        // animate!
        if (Input.GetKey(rightKey))
        {
            animator.SetBool("isWalk", true);
            spriteRenderer.flipX = false;
        }
        else if (Input.GetKey(leftKey))
        {
            animator.SetBool("isWalk", true);
            spriteRenderer.flipX = true;
        }
        else
        {
            animator.SetBool("isWalk", false);
        }
        
        // get jump input
        if (Input.GetKeyDown(jumpKey) && isGrounded)
        {
            //push the rigidbody UP
            rb.AddForce(transform.up * jumpForce);
        }

        // get interact input
        if (Input.GetKeyDown(interactKey))
        {
            interactionDetector.OnInteract();
        }

        if (Input.GetKeyDown(pauseKey))
        {
            pauseMenuPanel.gameObject.SetActive(true);
            Time.timeScale = 0f;
            Debug.Log("Pause key pressed");
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ground")
            isGrounded = true;
            // animate!
            animator.SetBool("isJump", false);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag != "Ground")
            return;

        isGrounded = false;
         // animate!
            animator.SetBool("isJump", true);
    }
}

