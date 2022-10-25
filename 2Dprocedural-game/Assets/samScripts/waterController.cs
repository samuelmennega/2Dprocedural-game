using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterController : MonoBehaviour
{

    private BoxCollider2D bc;
    // Start is called before the first frame update
    void Start()
    {
        bc = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerController player = collision.GetComponent<playerController>();
            Rigidbody2D playerRB = collision.GetComponent<Rigidbody2D>();
            player.myState = playerController.playerState.Landed;
            playerRB.drag = 10;

        }
    }
}
