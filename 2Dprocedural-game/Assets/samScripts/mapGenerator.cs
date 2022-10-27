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



    private void Awake()
    {
        GameObject newBackground = Instantiate(biomes[0].background, startingBackgroundLoc, Quaternion.identity);
        GameObject newGround = Instantiate(biomes[0].ground, startingGroundLoc, Quaternion.identity);
        newBackground.GetComponent<backgroundMovement>().Initialize(scrollSpeedInitial, decel);
        newGround.GetComponent<backgroundMovement>().Initialize(scrollSpeedInitial, decel);
        backgroundWidth = newBackground.GetComponent<backgroundMovement>().repeatWidth;
        groundWidth = newGround.GetComponent<backgroundMovement>().repeatWidth;


        Instantiate(biomes[0].ground, (startingGroundLoc + Vector2.right * backgroundWidth), Quaternion.identity).GetComponent<backgroundMovement>().Initialize(scrollSpeedInitial, decel);
        Instantiate(biomes[0].background, (startingBackgroundLoc + Vector2.right * backgroundWidth), Quaternion.identity).GetComponent<backgroundMovement>().Initialize(scrollSpeedInitial, decel);

    }




}


[System.Serializable]
public struct Biome
{
    public string name;
    public GameObject background;
    public GameObject ground;

}