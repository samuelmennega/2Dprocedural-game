using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    [Header("Launch Attributes")]
    public int launchSpeed;
    public playerState myState = playerState.Idle;
    public float currentScore;
    public Transform launchPoint;
    public float pullDistance;



    [Header("scene attributes")]
    public new Camera camera;


    private Rigidbody2D rb;
    private Vector3 MousePosInitial;

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.Sleep();

    }




    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            MousePosInitial = camera.ScreenToWorldPoint(Input.mousePosition);
            if(myState == playerState.Idle)
            {
                myState = playerState.PullBack;
            }
        }

        if(Input.GetMouseButtonUp(0))
        {
            if(myState == playerState.PullBack)
            {
                myState = playerState.Launching;
            }
        }

        switch(myState)
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
                currentScore = InAir();
                break;

            case playerState.Landed:
            //    Landed();
                break;
        }
    }

    void Idle()
    {
        rb.Sleep();
        transform.position = launchPoint.position;
    }

    void PullBack()
    {
        float mouseDist = (Vector3.Distance(launchPoint.position, (camera.ScreenToWorldPoint(Input.mousePosition))));
        if (mouseDist >= pullDistance) 
        {
            transform.position = Vector3.Lerp(launchPoint.position, camera.ScreenToWorldPoint(Input.mousePosition),(pullDistance/mouseDist));
        }

        else
        {
            transform.position = launchPoint.position + (camera.ScreenToWorldPoint(Input.mousePosition) - MousePosInitial);

        }
        // rb.Sleep();
        // transform.position = launchPoint.position + (camera.ScreenToWorldPoint(Input.mousePosition) - MousePosInitial);
    }

    void Launching()
    {
        float distance = Vector3.Distance(rb.position, launchPoint.position);
        Vector3 pos = rb.position;
        Vector3 launchDirection = launchPoint.position - pos;
        rb.WakeUp();
        rb.AddForce(launchDirection*launchSpeed, ForceMode2D.Impulse);
        myState = playerState.InAir;
    }

    float InAir()
    {
        return transform.position.x - launchPoint.position.x;
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

