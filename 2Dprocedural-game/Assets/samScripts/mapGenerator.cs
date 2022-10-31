using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapGenerator : MonoBehaviour
{
    private GameObject currentBiome;
    public Biome[] biomes;

    [Header("initialization")]
    public int mapLength;
    public static int chunkSize;
    public GameObject chunkPrefab;
    public static Vector2 startingBackgroundLoc;
    public static Vector2 startingGroundLoc;

    [Header("speed")]
    public static int scrollSpeedInitial;
    public static float decel;
    private float backgroundWidth;
    private float groundWidth;
    private GameObject[] launchObjects = new GameObject[4];




    private void Awake()
    {
        //instantiate chunks
        int numChunks = (mapLength / chunkSize) + 1;
        for(int i = 0; i <= numChunks; i++)
        {
            Instantiate(chunkPrefab, new Vector3(startingBackgroundLoc.x, startingBackgroundLoc.y, 0) + transform.right * chunkSize * i, Quaternion.identity);
        }
        //initialize background and ground
        int index = 0;
        GameObject newBackground = launchObjects[index++]= Instantiate(biomes[0].background, startingBackgroundLoc, Quaternion.identity);
        GameObject newGround = launchObjects[index++] = Instantiate(biomes[0].ground, startingGroundLoc, Quaternion.identity);
       
        backgroundWidth = newBackground.GetComponent<backgroundMovement>().repeatWidth;
        groundWidth = newGround.GetComponent<backgroundMovement>().repeatWidth;


        launchObjects[index++] = Instantiate(biomes[0].ground, (startingGroundLoc + Vector2.right * backgroundWidth), Quaternion.identity);
        launchObjects[index++] = Instantiate(biomes[0].background, (startingBackgroundLoc + Vector2.right * backgroundWidth), Quaternion.identity);

    }

    public void Launch(float launchSpeed, Vector2 launchDirection, float decelerationTime)
    {
        foreach(GameObject launchObject in launchObjects) {

            launchObject.GetComponent<backgroundMovement>().Launch(launchDirection.x * launchSpeed, decelerationTime);

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