using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Noise 
{
    /// <summary>
    /// Get a noise map texture of the specified size using the Perlin noise algorithm.
    /// Noise values will be stored in the generated noise map.
    /// </summary>
    /// <param name="width"> The width of the generated noise map. </param>
    /// <param name="height"> The height of the generated noise map.</param>
    /// <param name="scale"> The scale of the noise.</return>

    public static Texture2D GetNoiseMap(int width, int height, float scale)
    {
        // Create a new texture and set its size
        Texture2D noiseMapTexture = new Texture2D(width, height);

        // Iterate over each pixel in the texture
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                // Generate a noise value using Mathf.PerlinNoise
                float noiseValue = Mathf.PerlinNoise((float)x / width * scale, (float)y / height * scale);

                // Set the pixel colour based on the noise value
                noiseMapTexture.SetPixel(x, y, new Color(0, noiseValue, 0));
            }
        }

        // Apply the changes to the texture
        noiseMapTexture.Apply();

        return noiseMapTexture;
    }
}
