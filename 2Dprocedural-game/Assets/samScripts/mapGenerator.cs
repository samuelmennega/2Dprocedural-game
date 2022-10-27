using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapGenerator : MonoBehaviour
{
    private GameObject currentBiome;
    public Biome[] biomes;
    public Vector2 startingBackgroundLoc;
    public Vector2 startingGroundLoc;
    public int scrollSpeedInitial;
    public float decel;
    private float backgroundWidth;
    private float groundWidth;
    private GameObject[] launchObjects = new GameObject[4];



    private void Awake()
    {
        int i = 0;
        GameObject newBackground = launchObjects[i++]= Instantiate(biomes[0].background, startingBackgroundLoc, Quaternion.identity);
        GameObject newGround = launchObjects[i++] = Instantiate(biomes[0].ground, startingGroundLoc, Quaternion.identity);
       
        backgroundWidth = newBackground.GetComponent<backgroundMovement>().repeatWidth;
        groundWidth = newGround.GetComponent<backgroundMovement>().repeatWidth;


        launchObjects[i++] = Instantiate(biomes[0].ground, (startingGroundLoc + Vector2.right * backgroundWidth), Quaternion.identity);
        launchObjects[i++] = Instantiate(biomes[0].background, (startingBackgroundLoc + Vector2.right * backgroundWidth), Quaternion.identity);

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