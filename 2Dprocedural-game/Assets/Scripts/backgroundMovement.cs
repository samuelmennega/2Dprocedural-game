using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundMovement : MonoBehaviour
{
    private float scrollSpeedInitial;
    private float decel;
    private float scrollSpeed = 100;
    private float startTime;
    private bool launch = false;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(!launch)
        {
            return;
        }

        if(scrollSpeed >= 0) {

            launch = false;
                }
        scrollSpeed += decel * Time.deltaTime;

        transform.position = new Vector2(transform.position.x + scrollSpeed * Time.deltaTime, transform.position.y);

        if(transform.position.x < -192f)
        {
            transform.position = new Vector2(320f, transform.position.y);
        }
    }

    public void Launch(float speed,float decelerationTime)
    {
        scrollSpeed = -speed;
        decel = speed / decelerationTime;
        launch = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" || scrollSpeed >= 0)
        {
            collision.GetComponent<launchController>().myState = launchController.playerState.Landed;
        }
    }
}
