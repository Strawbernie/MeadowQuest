using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Android;

public class GPSLocation : MonoBehaviour
{
    public TextMeshProUGUI GPSStatus;
    public TextMeshProUGUI latitudeValue;
    public TextMeshProUGUI longitudeValue;
    public TextMeshProUGUI altitudeValue;
    public TextMeshProUGUI horizontalAccuracyValue;
    public TextMeshProUGUI timestampValue;
    public Transform player;
    public Transform Compass;
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
            latitudeValue.text = Input.location.lastData.latitude.ToString();
            longitudeValue.text = Input.location.lastData.longitude.ToString();
            altitudeValue.text = Input.location.lastData.altitude.ToString();
            horizontalAccuracyValue.text = Input.location.lastData.horizontalAccuracy.ToString();
            timestampValue.text = Input.location.lastData.timestamp.ToString();
            playerX = Input.location.lastData.latitude * 400000;
            playerY = Input.location.lastData.longitude * 400000;
            player.localPosition = new Vector3(playerX, playerY, 0);
            phoneRotation = Input.gyro.attitude;
            Compass.localRotation = new Quaternion(0,0,phoneRotation.z,phoneRotation.w);
        }
        else
        {
            // Service stopped
            GPSStatus.text = "Stop";
        }
    }
}
