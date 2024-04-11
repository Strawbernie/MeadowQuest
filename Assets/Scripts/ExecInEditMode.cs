using System.Collections;
using UnityEngine;
using System.Collections.Generic;

[ExecuteInEditMode]
public class ExecInEditMode : MonoBehaviour
{
    public float planeSize;
    public int numberOfObjectsToPlace;
    public GameObject[] prefabs;
    public int numberOfObjectsPlaced;
    public bool placeObject = false;
    public bool destroyObject = false;
    public float minimumDistance = 1f;

    public List<Vector3> flowerPositions = new List<Vector3>();

    // Update is called once per frame
    void Update()
    {
        if (placeObject)
        {
            for (int i = 0; i < numberOfObjectsToPlace; i++)
            {
                Vector3 randomSpawnPosition = GetRandomSpawnPosition(); // new Vector3(Random.Range(-planeSize, planeSize), 1, Random.Range(-planeSize, planeSize));
                GameObject instantiatedFlower = Instantiate(prefabs[Random.Range(0, prefabs.Length)], randomSpawnPosition, Quaternion.Euler(0, Random.Range(0, 360), 0)); //set roation y to random value
                instantiatedFlower.transform.parent = transform;

                flowerPositions.Add(randomSpawnPosition);

                numberOfObjectsPlaced = transform.childCount;
            }
            placeObject = false;
        }
        if (destroyObject)
        {
            if (transform.childCount > 0)
            {
                DestroyImmediate(transform.GetChild(transform.childCount - 1).gameObject);

                if (flowerPositions.Count > 0)
                {
                    flowerPositions.RemoveAt(flowerPositions.Count - 1);
                }

                numberOfObjectsPlaced = transform.childCount;
            }
            destroyObject = false;
        }
    }

    private Vector3 GetRandomSpawnPosition()
    {
        Vector3 randomSpawnPosition = Vector3.zero;
        int attempts = 0;

        while (attempts < 100) // Limiting attempts to avoid infinite loop
        {
            randomSpawnPosition = new Vector3(Random.Range(-planeSize, planeSize), 1, Random.Range(-planeSize, planeSize));
            if (!IsTooCloseToExistingPosition(randomSpawnPosition))
            {
                return randomSpawnPosition; // Return the position if it's not too close to existing positions
            }
            attempts++;
        }

        Debug.LogWarning("Could not find a suitable spawn position after 100 attempts.");
        return Vector3.zero;
    }
    private bool IsTooCloseToExistingPosition(Vector3 position)
    {
        foreach (Vector3 existingPosition in flowerPositions)
        {
            if (Vector3.Distance(position, existingPosition) < minimumDistance)
            {
                return true;
            }
        }
        return false;
    }
}
