using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterController : MonoBehaviour
{

    private BoxCollider2D bc;
    public GameObject playerObject;
    private Rigidbody2D playerRB;
    private playerController player;
    private float initialDrag;
    private float initialGravity;
    // Start is called before the first frame update
    void Start()
    {
        bc = GetComponent<BoxCollider2D>();
        playerRB = playerObject.GetComponent<Rigidbody2D>();
        player = playerObject.GetComponent<playerController>();
        initialDrag = playerRB.drag;
        initialGravity = playerRB.gravityScale;


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
          
            player.myState = playerController.playerState.Landed;
            playerRB.drag = 10;
            playerRB.gravityScale = 0;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            player = collision.GetComponent<playerController>();
            playerRB = collision.GetComponent<Rigidbody2D>();
            playerRB.drag = initialDrag;
            playerRB.gravityScale = initialGravity;

        }
    }
}
