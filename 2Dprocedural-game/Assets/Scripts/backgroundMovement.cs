using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundMovement : MonoBehaviour
{
  

  // [HideInInspector]
    [SerializeField]
    public static float repeatWidth, repeatHeight;










    public void Awake()
    {
        repeatWidth = gameObject.GetComponent<SpriteRenderer>().size.x;
        repeatHeight = gameObject.GetComponent<SpriteRenderer>().size.y;

    }

    // Update is called once per frame
    void Update()
    {
        if(!mapGenerator.launch)
        {
            return;
        }





        if(transform.position.x < -repeatWidth)
        {
            Instantiate(gameObject, new Vector3(transform.position.x + repeatWidth * 2, transform.position.y, transform.position.z), Quaternion.identity).transform.SetParent(transform.parent);
            GameObject.Destroy(gameObject);
        }
       
    }





    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && mapGenerator.scrollSpeed >= 0)
        {
            collision.GetComponent<launchController>().myState = launchController.playerState.Landed;
        }
    }
}
