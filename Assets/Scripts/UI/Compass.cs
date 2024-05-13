using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class Compass : MonoBehaviour
{
    Gyroscope m_Gyro;
    Quaternion phoneRotation;
    public GameObject compass;

    void Start()
    {
        Permission.RequestUserPermission(Permission.FineLocation);
    }
    private void Awake()
    {
        //Set up and enable the gyroscope (check your device has one)
        m_Gyro = Input.gyro;
        m_Gyro.enabled = true;
    }
    void Update()
    {
        phoneRotation = Input.gyro.attitude;
        compass.transform.localRotation = new Quaternion(0, 0, -phoneRotation.z, phoneRotation.w);
    }
}
