using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{

    [Header("references")]
    public GameObject playerObject;
    public Transform launchPos;

    [Header("camera options")]
    public float smoothTime;
    public Vector3 launchOffset = new Vector3(0, 0, -10f);


    private Vector3 playerPosition;
    private launchController player;
    private Vector3 velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        playerPosition = playerObject.transform.position;
        player = playerObject.GetComponent<launchController>();

        if(player.myState == launchController.playerState.Idle || player.myState == launchController.playerState.PullBack)
        {
            gameObject.transform.position = launchPos.position + launchOffset;
        }

        else
        {
            gameObject.transform.position = Vector3.SmoothDamp(gameObject.transform.position, new Vector3(playerPosition.x, playerPosition.y, -10f), ref velocity,smoothTime);
        }
    }
}
