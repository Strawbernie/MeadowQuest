using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Android;
using Niantic.Lightship.Maps.Coordinates;
using Niantic.Lightship.Maps;

public class GPSLocation : MonoBehaviour
{
    public TextMeshProUGUI GPSStatus;
    public TextMeshProUGUI latitudeValue;
    public TextMeshProUGUI longitudeValue;
    public TextMeshProUGUI altitudeValue;
    public TextMeshProUGUI horizontalAccuracyValue;
    public TextMeshProUGUI timestampValue;
    private SerializableLatLng Location;
    public Transform player;
    public LightshipMapView LMV;
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
            GPSStatus.text = "Time Out";
            yield break;
        }

        //Receiving Location failed
        if(Input.location.status == LocationServiceStatus.Failed)
        {
            GPSStatus.text = "Unable to determine device location";
            yield break;
        }
        else
        {
            GPSStatus.text = "Running";
            InvokeRepeating("UpdateGPSData", .5f, 1f);
            //Received User's Location
        }
    }

    private void UpdateGPSData()
    {
        if (Input.location.status == LocationServiceStatus.Running)
        {
            //Access to GPS values granted and initialized
            GPSStatus.text = "Running";
            //Visually represent data
            latitudeValue.text = Input.location.lastData.latitude.ToString();
            longitudeValue.text = Input.location.lastData.longitude.ToString();
            altitudeValue.text = Input.location.lastData.altitude.ToString();
            horizontalAccuracyValue.text = Input.location.lastData.horizontalAccuracy.ToString();
            timestampValue.text = Input.location.lastData.timestamp.ToString();
            //Get player location
            Location = new SerializableLatLng(Input.location.lastData.latitude, Input.location.lastData.longitude);
            //Calculate player location to scene position
            player.localPosition = LMV.LatLngToScene(Location);
            player.localPosition = new Vector3(player.localPosition.x, 50, player.localPosition.z);
            //Get player phone rotation
            phoneRotation = Input.gyro.attitude;
            player.localRotation = new Quaternion(0, -phoneRotation.z, 0, phoneRotation.w);
        }
        else
        {
            // Service stopped
            GPSStatus.text = "Stop";
        }
    }
}
