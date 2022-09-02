using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyHole : MonoBehaviour
{
    private Color normalColor;
    private bool keyHoleUnlocked;

    void Start()
    {
        normalColor = GetComponent<SpriteRenderer>().color;
        keyHoleUnlocked = false;
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!keyHoleUnlocked && collision.gameObject.tag == "Player")
        {
            if (collision.gameObject.GetComponent<PlayerProtoMovement>().PlayerSpendKey())
            {
                keyHoleUnlocked = true;
                GetComponent<SpriteRenderer>().color = Color.green;
            }
        }   
    }
}
