using System;
using UnityEngine;

public class PlayerProtoMovement : MonoBehaviour
{
    [SerializeField] private float HorizontalSpeedScale;
    [SerializeField] float JumpForce;
    [SerializeField] float gravityModifier;
    private BoxCollider2D collision; 
    private Rigidbody2D body;
    private Animator animControl;
    private float defaultScale;
    private bool isFalling;
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
        animControl = GetComponent<Animator>();
        keyCount = 0;
        defaultScale = transform.localScale.x;
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
        keyCount = Math.Max(0, keyCount - 1);
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
            horizontalInput = Input.GetAxis("Horizontal");
            VerticaInput = Input.GetAxis("Vertical");

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

            animControl.SetFloat("hSpeed", Mathf.Abs(body.velocity.x));
            isFalling = (body.velocity.y < -0.2f) && !Grounded();
            animControl.SetBool("isFalling", isFalling);

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
            transform.localScale = Vector2.one * defaultScale;
        }
        else if (horizontalInput < -0.01f)
        {
            transform.localScale = (new Vector2(-1, 1)) * defaultScale;
        }
    }

    void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, JumpForce);
        animControl.SetTrigger("jumpTrigger");
    }
    bool Grounded()
    {
        RaycastHit2D ray = Physics2D.BoxCast(collision.bounds.center, collision.bounds.size, 0.0f, Vector2.down, 0.1f, GroundLayer);
        return ray;
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
