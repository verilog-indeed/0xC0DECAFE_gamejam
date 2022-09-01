using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProtoMovement : MonoBehaviour
{
    [SerializeField] private float HorizontalSpeedScale;
    [SerializeField] float JumpForce;
    private BoxCollider2D collision; 
    private Rigidbody2D body;
    float horizontalInput;
    float VerticaInput;

    bool IsSpirit;
    Color AliveC;

    [SerializeField] LayerMask GroundLayer;

    void Awake()
    {
        collision = GetComponent<BoxCollider2D>();
        body = GetComponent<Rigidbody2D>();
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
        Die();
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
            body.gravityScale = 1;

            this.gameObject.GetComponent<SpriteRenderer>().color = AliveC;
            if (Input.GetKeyDown(KeyCode.Space)&& Grounded())
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
    void Die()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            IsSpirit = !IsSpirit;
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
}
