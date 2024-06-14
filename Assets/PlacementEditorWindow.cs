using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public class PlacementEditorWindow : EditorWindow 
{ 
    private Texture2D noiseMapTexture;
    private float density = 0.5f;
    private GameObject prefab;
    public Transform placedObjectParent;

    [MenuItem("Tools/Wizards Code/Tutorial/Plant Placement")]

    public static void ShowWindow()
    {
        GetWindow<PlacementEditorWindow>("Plant Placement");
    }
    private void OnGUI()
    {
        EditorGUILayout.BeginHorizontal();
        noiseMapTexture = (Texture2D)EditorGUILayout.ObjectField("Noise Map Texture", noiseMapTexture, typeof(Texture2D), false);
        if (GUILayout.Button("Generate Noise")) 
        {
            int width = (int)Terrain.activeTerrain.terrainData.size.x;
            int height = (int)Terrain.activeTerrain.terrainData.size.y;
            float scale = 5;
            noiseMapTexture = Noise.GetNoiseMap(width, height, scale);
        }
        EditorGUILayout.EndHorizontal();

        density = EditorGUILayout.Slider("Density", density, 0, 1);

        prefab = (GameObject)EditorGUILayout.ObjectField("Object Prefab", prefab, typeof(GameObject), false);

        if (GUILayout.Button("Place Objects"))
        {
            PlaceObject(Terrain.activeTerrain, noiseMapTexture, density, prefab);
        }
    }
    ///<summary>
    ///Place an objects at each location on the terrain where the noise map is above a certified threshold defined by the desired density.
    ///</summary>
    ///<param name="terrain"> The terrain upon which to place the objects </param>
    ///<param name="density"> The density of the objects where 1 is every tested location and 0 is no placementsat all</param>

    public static void PlaceObject(Terrain terrain, Texture2D noiseMapTexture, float density, GameObject prefab)
    {
         Transform placedObjectParent = new GameObject("PlacedObjects").transform;

        for (int x = 0; x < terrain.terrainData.size.x; x++)
        {
            for (int z = 0; z < terrain.terrainData.size.z; z++)
            {
                float noiseMapValue = noiseMapTexture.GetPixel(x, z).g;

                // If the value is above the threshold, instantiate a plant at this location
                if (noiseMapValue > 1 - density)
                {
                    Vector3 pos = new Vector3(x, 0, z);
                    pos.y = terrain.terrainData.GetInterpolatedHeight(x / terrain.terrainData.size.x, z / (float)terrain.terrainData.size.y);

                    GameObject go = Instantiate(prefab, pos, Quaternion.identity);
                    go.transform.SetParent(placedObjectParent);
                }
            }
        }
    }

    private void Start()
    {
        Debug.Log(placedObjectParent.name + " has " + placedObjectParent.transform.childCount + " children");
    }
}
