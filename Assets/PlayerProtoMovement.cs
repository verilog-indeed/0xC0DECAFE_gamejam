using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProtoMovement : MonoBehaviour
{
    [SerializeField] private float HorizontalSpeedScale; 
    private BoxCollider2D collision; 
    private Rigidbody2D body;
    void Awake()
    {
        collision = GetComponent<BoxCollider2D>();
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Move left and right
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(HorizontalSpeedScale * horizontalInput, body.velocity.y);

        //Flip sprite to correct orientation
        if (horizontalInput > 0.01f) {
            transform.localScale = Vector2.one;
        } else if (horizontalInput < -0.01f) {
            transform.localScale = new Vector2(-1, 1);
        }

    }
}
