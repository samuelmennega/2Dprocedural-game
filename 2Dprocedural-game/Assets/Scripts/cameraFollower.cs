using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollower : MonoBehaviour
{
    private Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    public bool bounds;
    public Vector3 minCameraPos;
    public Vector3 maxCameraPos;


    //public Camera upperCamera, mainCamera, lowerCamera;


    void Start()
    {
        //upperCamera.gameObject.SetActive(false);
        //lowerCamera.gameObject.SetActive(false);
    }

    void LateUpdate()
    {
        target = GameObject.FindWithTag("Player").transform;
        if (target == null || (!mapGenerator.launch && target.gameObject.GetComponent<TarodevController.PlayerController>().Grounded))
        {
            return;

        }

        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;


        if (bounds)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minCameraPos.x, maxCameraPos.x),
                Mathf.Clamp(transform.position.y, minCameraPos.y, maxCameraPos.y),
                Mathf.Clamp(transform.position.z, minCameraPos.z, maxCameraPos.z));
        }



    }
}
