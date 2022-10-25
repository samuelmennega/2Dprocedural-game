using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class noiseGenerator : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static float[,] Generate(int width, int height, float scale, Waves[] waves, Vector2 offset, float amplitudeScale)
    {
        float[,] noisemap = new float[width, height];
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                float samplePosX = (float)x * scale + offset.x;
                float samplePosY = (float)y * scale + offset.y;
                float normalization = 0.0f;
                foreach (Waves wave in waves)
                {
                    noisemap[x, y] += wave.amplitude *  ((1.0f-amplitudeScale)*Mathf.PerlinNoise(samplePosX * wave.frequency + wave.seed, samplePosY * wave.frequency + wave.seed) + (amplitudeScale));
                    normalization += wave.amplitude;
                }
                noisemap[x, y] /= normalization;
            }
        }
        return noisemap;
    }


}

[System.Serializable]
public class Waves 
{
    public float seed = 1.0f;
    public float frequency =1.0f;
    public float amplitude =1.0f;


}

