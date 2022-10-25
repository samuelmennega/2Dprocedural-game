using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallax : MonoBehaviour
{
    private float  startpos;
    public new GameObject camera;
    public float parallaxFactor;
    void Start()
    {
        startpos = transform.position.x;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        float dist = (camera.transform.position.x * parallaxFactor);

        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);
    }
}
