using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundMovement : MonoBehaviour
{
  

    [HideInInspector]
    public float scrollSpeedInitial, repeatWidth, repeatHeight, decel, scrollSpeed, startTime;
    [HideInInspector]
    public bool launch = false, first = true;





    // Start is called before the first frame update
    void Awake()
    {
        repeatWidth = gameObject.GetComponent<SpriteRenderer>().size.x;
        repeatHeight = gameObject.GetComponent<SpriteRenderer>().size.y;
        if (first)
        {
           //Instantiate(gameObject, new Vector3(transform.position.x + repeatWidth, transform.position.y, transform.position.z), Quaternion.identity);
            first = false;
        }
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

        if(transform.position.x < -repeatWidth)
        {
            //Instantiate(gameObject, new Vector3(transform.position.x + repeatWidth * 2, transform.position.y, transform.position.z), Quaternion.identity);
            GameObject.Destroy(gameObject);
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
