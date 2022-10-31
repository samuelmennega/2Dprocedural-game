using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapGenerator : MonoBehaviour
{
    private GameObject currentBiome;
    public Biome[] biomes;

    [Header("initialization")]
    public int mapLength;
    public int set_chunkSize;
    public static int chunkSize;
    public GameObject chunkPrefab;
    public Vector2 set_startingBackgroundLoc;
    public Vector2 set_startingGroundLoc;
    public static Vector2 startingBackgroundLoc;
    public static Vector2 startingGroundLoc;
    public Transform mapMover;

    [Header("speed")]
    public static float decel;


    private float backgroundWidth;
    private float groundWidth;
    private static GameObject[] launchObjects = new GameObject[4];
    //private static List<GameObject> activeChunks = new List<GameObject>();
    private static List<GameObject> inactiveChunks = new List<GameObject>();
    public static float scrollSpeed;
    public static float deltaMovement;
    public static bool launch = false;



    private void Awake()
    {
        //set statics
        chunkSize = set_chunkSize;
        startingBackgroundLoc = set_startingBackgroundLoc;
        startingGroundLoc = set_startingGroundLoc;

        //instantiate chunks
        int numChunks = (mapLength / chunkSize);

        for (int i = 0; i <= numChunks; i++)
        {
            GameObject chunk = Instantiate(chunkPrefab, new Vector3(startingBackgroundLoc.x, startingBackgroundLoc.y, 0) + transform.right * chunkSize * i, Quaternion.identity);
            chunk.transform.SetParent(mapMover);
            inactiveChunks.Add(chunk);
        }

        //initialize background and ground
        Instantiate(biomes[0].background, startingBackgroundLoc, Quaternion.identity).transform.SetParent(mapMover);
        Instantiate(biomes[0].ground, startingGroundLoc, Quaternion.identity).transform.SetParent(mapMover);
        backgroundWidth = backgroundMovement.repeatWidth;
        groundWidth = backgroundMovement.repeatWidth;


        Instantiate(biomes[0].ground, (startingGroundLoc + Vector2.right * backgroundWidth), Quaternion.identity).transform.SetParent(mapMover);
        Instantiate(biomes[0].background, (startingBackgroundLoc + Vector2.right * backgroundWidth), Quaternion.identity).transform.SetParent(mapMover);

        

    }

    private void Update()
    {
        if(scrollSpeed > 0)
        {
            launch = false;
        }
        mapMovement();
        manageChunks();
    }

    public static void Launch(float launchSpeed, Vector2 launchDirection, float deceleration)
    {
        scrollSpeed = -launchSpeed * launchDirection.x;
        decel = deceleration;
        launch = true;


    }
    
    void mapMovement()
    {
        if(launch)
        {
            scrollSpeed += decel * Time.deltaTime;
            deltaMovement = scrollSpeed * Time.deltaTime;
            mapMover.position = new Vector3(mapMover.position.x + deltaMovement, mapMover.position.y, mapMover.position.z);
        }

    }

    void manageChunks()
    {
        foreach(GameObject chunk in inactiveChunks)
        {
            if (chunk.transform.position.x <= transform.position.x - chunkSize)
            {
                chunk.SetActive(false);
            }

            else if (chunk.transform.position.x <= transform.position.x + chunkSize)
            {
                chunk.SetActive(true);
            }
        }





    }




}


[System.Serializable]
public struct Biome
{
    public string name;
    public GameObject background;
    public GameObject ground;

}