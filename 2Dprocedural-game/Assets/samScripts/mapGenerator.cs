using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapGenerator : MonoBehaviour
{

    [Header("prefabs")]
    public GameObject tilePrefab;
    public GameObject lavaPrefab;


    [Header("dimensions")]
    public int width = 50;
    public int height = 50;
    public float scale = 1.0f;
    public Vector2 offset;

    [Header("lava options")]
    public int lavaDepth;
    public float lavaChance = 0.1f;
    public Waves[] heatWaves;
    public float[,] heatMap;
    public int heatStep;
    public float maxHeat = 0.20f;
    // Start is called before the first frame update

    private int rockTiles = 0;
    private int lavaTiles = 0;

    void Start()
    {
        int numNoiseMaps = height / heatStep;
        for (int i = 0; i <= numNoiseMaps; i++)
        {
            float heatIncrease = i * (maxHeat) / numNoiseMaps;
            generateMap(width, heatStep, new Vector2(offset.x, offset.y + (heatStep*i)), heatIncrease);
        }

        Debug.Log("Rocks: "+ rockTiles + "Lava:"+ lavaTiles);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void generateMap(int width, int height, Vector2 offset, float amplitudeScale)
    {
        heatMap = noiseGenerator.Generate(width, height, scale, heatWaves, offset,  amplitudeScale);

        for(int x = 0; x < width; x++)
        {
            for(int y = 0; y < height; y++)
            {
                GameObject tile = SelectTileType(heatMap[x, y]);
                Instantiate(tile, new Vector3(x+offset.x, -y-offset.y, 0), Quaternion.identity);
                //tile.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, heatMap[x, y]);
            }
        }
    }

    GameObject SelectTileType(float heatMapValue)
    {
        
        if (Random.Range(0.0f, 100.0f) <= 100 * heatMapValue * lavaChance)
        {
            lavaTiles ++;
            return lavaPrefab;
        }

        else
        {
            rockTiles++;
            return tilePrefab;
        }
    }
}
