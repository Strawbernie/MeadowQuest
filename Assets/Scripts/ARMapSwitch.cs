using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ARMapSwitch : MonoBehaviour
{
    public bool mapOpen;
   // public GameObject LocationButtons;
    public GameObject ARCamera;
    public GameObject MapCamera;
    public GameObject PlayerIndicator;

    public void OnButtonPress()
    {
        if (!mapOpen)
        {
            //LocationButtons.SetActive(true);
            MapCamera.SetActive(true);
            ARCamera.SetActive(false);
            PlayerIndicator.SetActive(true);
        }
        else if (mapOpen)
        {
            //LocationButtons.SetActive(false);
            MapCamera.SetActive(false);
            ARCamera.SetActive(true);
            PlayerIndicator.SetActive(false);
        }
    }
}
