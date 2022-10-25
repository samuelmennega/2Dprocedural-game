using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundMovement : MonoBehaviour
{
    public float scrollSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x + scrollSpeed * Time.deltaTime, transform.position.y);

        if(transform.position.x < -192f)
        {
            transform.position = new Vector2(320f, transform.position.y);
        }
    }
}
