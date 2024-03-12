using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public float latitude;
    private float cameraX;
    public float longitude;
    private float cameraY;
    private float cameraZ = -10;
    public Transform Camera1;
    public GameObject Map;
    public GameObject FalseMap;

    void Start()
    {
        cameraX = longitude * 400000;
        cameraY = latitude * 400000;
    }

    public void OnButtonPress()
    {
        Camera1.localPosition = new Vector3(cameraX, cameraY, cameraZ);
        Map.SetActive(true);
        FalseMap.SetActive(false);
    }
}
