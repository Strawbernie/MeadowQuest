using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailerCamera : MonoBehaviour
{
    public float moveSpeed;

    void Update()
    {
        if (transform.position.z < 12)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
        }
    }
}
