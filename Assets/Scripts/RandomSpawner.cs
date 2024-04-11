using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public GameObject[] prefabs;
    public int numberOfObjects;
    public float planeSize;

    // Start is called before the first frame update
    void Start()
    {
        //spawn object at random position and the number of objects is less or equal to 10
        for (int i = 0; i < numberOfObjects; i++)
        {
            Vector3 randomSpawnPosition = new Vector3(Random.Range(-planeSize, planeSize), 1, Random.Range(-planeSize, planeSize));
            Instantiate(prefabs[Random.Range(0, prefabs.Length)], randomSpawnPosition, Quaternion.identity);
        }
    }
}
