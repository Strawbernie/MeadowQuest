using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Android;
using Niantic.Lightship.Maps.Coordinates;
using Niantic.Lightship.Maps;

public class GPSLocation : MonoBehaviour
{
    private SerializableLatLng Location;
    public Transform player;
    public LightshipMapView LMV;
    public Camera ARCamera;
    int clippingValue;
    float playerX;
    float playerY;
    bool locationEnabled;
    Gyroscope m_Gyro;
    Quaternion phoneRotation;
    // Start is called before the first frame update
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
    private void Update()
    {
        if (!locationEnabled && Permission.HasUserAuthorizedPermission(Permission.FineLocation))
        {
            locationEnabled = true;
            StartCoroutine(GPSLoc());
        }
    }

    IEnumerator GPSLoc()
    {
        //Check if the user has their location enabled
        if (!Input.location.isEnabledByUser)
        {
            yield break;
        }

        //Start using their location
        Input.location.Start();

        //Wait until their location initializes
        int maxWaitingTime = 20;
        while(Input.location.status == LocationServiceStatus.Initializing && maxWaitingTime > 0)
        {
            yield return new WaitForSeconds(1);
            maxWaitingTime--;
        }

        //Service did not initialize in 20 seconds
        if(maxWaitingTime < 1)
        {
            yield break;
        }

        //Receiving Location failed
        if(Input.location.status == LocationServiceStatus.Failed)
        {
            yield break;
        }
        else
        {
            InvokeRepeating("UpdateGPSData", .5f, 1f);
            //Received User's Location
        }
    }

    private void UpdateGPSData()
    {
        if (Input.location.status == LocationServiceStatus.Running)
        {
            Location = new SerializableLatLng(Input.location.lastData.latitude, Input.location.lastData.longitude);
            player.localPosition = LMV.LatLngToScene(Location);
            player.localPosition = new Vector3(player.localPosition.x, 50, player.localPosition.z);
            phoneRotation = Input.gyro.attitude;
            player.localRotation = new Quaternion(0, -phoneRotation.z, 0, phoneRotation.w);
        }
    }
}
