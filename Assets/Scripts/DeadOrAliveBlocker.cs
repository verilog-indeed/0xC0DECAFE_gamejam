using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DeadOrAliveBlocker : MonoBehaviour
{
    [SerializeField] private bool blockIfAlive;
    private Collider2D gateCollider;
    private GameObject player;
    private PlayerProtoMovement moveScript;
    private Collider2D playerCollider;
    void Start()
    {
        gateCollider = GetComponent<BoxCollider2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        moveScript = player.GetComponent<PlayerProtoMovement>();
        playerCollider = player.GetComponent<Collider2D>();
    }

    void Update()
    {
        if (player != null)
        {
            //block player if they are dead and the object is set to block the dead
            // or block player if they are not dead and object is set to not block the dead
            if (blockIfAlive == moveScript.PlayerIsSpirit())
            {
                Physics2D.IgnoreCollision(playerCollider, gateCollider);
            }
            else
            {
                //stop ignoring collisions
                Physics2D.IgnoreCollision(playerCollider, gateCollider, false);
            }
        }
    }
}
