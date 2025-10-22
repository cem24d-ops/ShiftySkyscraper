using UnityEngine;

public class PlayerTestMovement : MonoBehaviour
{
    public KeyCode leftKey = KeyCode.A;
    public KeyCode rightKey = KeyCode.D;
    public KeyCode jumpKey = KeyCode.W;
    public KeyCode interactKey = KeyCode.S;
    public float moveSpeed = 10.0f;

    public float jumpForce = 500.0f;

    Rigidbody2D rb;

    public bool isGrounded = false;

    public bool shouldJump = false;

    public InteractionDetector interactionDetector;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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

        // get jump input
        if (Input.GetKeyDown(jumpKey) && isGrounded)
        {
            shouldJump = true;
        }

        // get interact input
        if (Input.GetKeyDown(interactKey))
        {
            interactionDetector.OnInteract();
        }
    }

    void FixedUpdate()
    {
        if (shouldJump == true)
        {
            // quickly set back to false so we don't double-jump
            shouldJump = false;

            //push the rigidbody UP
            rb.AddForce(transform.up * jumpForce);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
            isGrounded = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
            isGrounded = false;
    }
}
