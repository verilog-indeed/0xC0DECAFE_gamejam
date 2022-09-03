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
        GameObject go = collision.gameObject;
        if (!keyHoleUnlocked && go.tag == "Player")
        {
            if (go.GetComponent<PlayerProtoMovement>().PlayerSpendKey())
            {
                keyHoleUnlocked = true;
                this.GetComponent<SpriteRenderer>().color = Color.green;
            }
        }   
    }
}
