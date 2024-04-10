using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StressTest : MonoBehaviour
{
    public GameObject Flower;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(InstantiateFlower());
    }

    IEnumerator InstantiateFlower()
    {
        for (int i = 0; i < 167; i++)
        {
            for (int q = 0; q < 50; q++)
            {
                Instantiate(Flower, new Vector3(Random.Range(7, -7), 0, Random.Range(8, -7)), Quaternion.identity);
            }
            yield return new WaitForEndOfFrame();
        }
    }
    // Update is called once per frame
    void Update()
    {
       
    }
}
