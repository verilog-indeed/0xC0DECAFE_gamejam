using System;
using UnityEngine;

public class PlayerProtoMovement : MonoBehaviour
{
    [SerializeField] private float HorizontalSpeedScale;
    [SerializeField] float JumpForce;
    [SerializeField] float gravityModifier;
    private BoxCollider2D collision; 
    private Rigidbody2D body;
    float horizontalInput;
    float VerticaInput;
    int keyCount;

    bool IsSpirit;
    Color AliveC;

    [SerializeField] LayerMask GroundLayer;

    void Awake()
    {
        collision = GetComponent<BoxCollider2D>();
        body = GetComponent<Rigidbody2D>();
        keyCount = 0;
    }
    private void Start()
    {
        AliveC = this.gameObject.GetComponent<SpriteRenderer>().color;
    }

    // Update is called once per frame
    void Update()
    {
        MovementInput();
        Flip();

    }

    private void GrabKey(GameObject grabbedKey)
    {
        keyCount++;

        //remove key from level
        grabbedKey.SetActive(false);
    }

    public bool PlayerIsSpirit() {
        return IsSpirit;
    }

    public bool PlayerSpendKey()
    {
        bool playerHasKey = keyCount > 0;
        keyCount = Math.Min(0, keyCount - 1);
        return playerHasKey;
    }

    private void FixedUpdate()
    {
        Move();
    }
    void MovementInput()
    {
        if (IsSpirit)
        {
            horizontalInput = Input.GetAxisRaw("Horizontal");
            VerticaInput = Input.GetAxisRaw("Vertical");

            body.gravityScale = 0;
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        }
        else
        {
            horizontalInput = Input.GetAxis("Horizontal");
            body.gravityScale = gravityModifier;

            this.gameObject.GetComponent<SpriteRenderer>().color = AliveC;
            if (Input.GetKeyDown(KeyCode.Space) && Grounded())
            {
                Jump();
            }
        }
        
    }
    void Move()
    {
        if (IsSpirit)
        {
            body.velocity = new Vector2(HorizontalSpeedScale * horizontalInput, HorizontalSpeedScale* VerticaInput);
        }
        else
        {
            body.velocity = new Vector2(HorizontalSpeedScale * horizontalInput, body.velocity.y);
        }
    }
    void Flip()
    {
        if (horizontalInput > 0.01f)
        {
            transform.localScale = Vector2.one;
        }
        else if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector2(-1, 1);
        }
    }

    void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, JumpForce);
    }
    bool Grounded()
    {
        return Physics2D.OverlapCircle(new Vector2(transform.position.x, transform.position.y - 0.5f), 0.3f, GroundLayer);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch(collision.gameObject.tag)
        {
            case "Hazard":
                IsSpirit = true;
                break;
            case "Resurrector":
                IsSpirit = false;
                break;
            case "Key":
                GrabKey(collision.gameObject);
                break;
            default:
                break;
        }
    }
}
