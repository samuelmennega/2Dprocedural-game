using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class launchController : MonoBehaviour
{

    [Header("Launch Attributes")]
    public int launchSpeed;
    public playerState myState = playerState.Idle;
    public Transform launchPoint;
    public float pullDistance;
    public float decelerationTime;



    [Header("scene attributes")]
    public new Camera camera;
    public GameObject mapManager;
    private mapGenerator mapGen;


   
    private Vector3 MousePosInitial;

    private TarodevController.PlayerController pc;
    
    private void Awake()
    {

        pc = gameObject.GetComponent<TarodevController.PlayerController>();
        pc.enabled = false;
        mapGen = mapManager.GetComponent<mapGenerator>();
    }




    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MousePosInitial = camera.ScreenToWorldPoint(Input.mousePosition);
            if (myState == playerState.Idle)
            {
                myState = playerState.PullBack;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (myState == playerState.PullBack)
            {
                myState = playerState.Launching;
            }
        }

        switch (myState)
        {
            case playerState.Idle:
                Idle();
                break;

            case playerState.PullBack:
                PullBack();
                break;

            case playerState.Launching:
                Launching();
                break;

            case playerState.InAir:
                break;

            case playerState.Landed:
                Landed();
                break;
        }
    }

    void Idle()
    {
        pc.enabled = false;

        transform.position = launchPoint.position;
    }

    void PullBack()
    {
        pc.enabled = false;
        
        
        Vector3 pullDirection = camera.ScreenToWorldPoint(Input.mousePosition) - MousePosInitial;
        float pullMagnitude = pullDirection.magnitude;

        if (pullDirection.x >= 0)
        {
            pullDirection.x = 0;
        }

        if (pullMagnitude >= pullDistance)
        {
            transform.position = Vector3.Lerp(launchPoint.position, launchPoint.position + pullDirection, pullDistance/pullMagnitude);
        }

        else
        {
            transform.position = Vector3.Lerp(launchPoint.position, launchPoint.position + pullDirection, 1);

            //transform.position = launchPoint.position + (camera.ScreenToWorldPoint(Input.mousePosition) - MousePosInitial);

        }

       
        // rb.Sleep();
        // transform.position = launchPoint.position + (camera.ScreenToWorldPoint(Input.mousePosition) - MousePosInitial);
    }

    void Launching()
    {
        float distance = Vector3.Distance(transform.position, launchPoint.position);
        Vector3 pos = transform.position;
        Vector3 launchDirection = launchPoint.position - pos;

        //rb.AddForce(new Vector2(0f, launchDirection.y) * launchSpeed, ForceMode2D.Impulse);

        mapGen.Launch(launchSpeed,launchDirection,decelerationTime);
         

        pc.enabled = true;
        pc.AddToSpeed(0, launchDirection.y * launchSpeed);
        myState = playerState.InAir;
    }

    float InAir()
    {
        
       
        return transform.position.x - launchPoint.position.x;
    }

    void Landed()
    {
        pc.enabled = false;
    }
    public enum playerState
    {
        Idle,
        PullBack,
        Launching,
        InAir,
        Landed
    }

}
