using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundMovement : MonoBehaviour
{
  

   [HideInInspector]
    public float repeatWidth, repeatHeight, decel, scrollSpeed;

    [HideInInspector]
    public bool launch = false;








    public void Awake()
    {
        repeatWidth = gameObject.GetComponent<SpriteRenderer>().size.x;
        repeatHeight = gameObject.GetComponent<SpriteRenderer>().size.y;

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
            GameObject newObject = Instantiate(gameObject, new Vector3(transform.position.x + repeatWidth * 2, transform.position.y, transform.position.z), Quaternion.identity);
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
        if(collision.tag == "Player" && scrollSpeed >= 0)
        {
            collision.GetComponent<launchController>().myState = launchController.playerState.Landed;
        }
    }
}
