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
        for (int i = 0; i < 500; i++)
        {
            Instantiate(Flower, new Vector3(Random.Range(4.5F, -4.5F), 0, Random.Range(4.5F, -4.5F)),Quaternion.identity);
            yield return new WaitForEndOfFrame();
        }
    }
    // Update is called once per frame
    void Update()
    {
       
    }
}
