using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ARMapSwitch : MonoBehaviour
{
    public TextMeshProUGUI ButtonText;
    bool mapOpen = false;
    public GameObject LocationButtons;
    public GameObject ARCamera;
    public GameObject MapCamera;
    public GameObject PlayerIndicator;

    public void OnButtonPress()
    {
        if (!mapOpen)
        {
            mapOpen = true;
            //LocationButtons.SetActive(true);
            ButtonText.text = "To AR";
            MapCamera.SetActive(true);
            ARCamera.SetActive(false);
            PlayerIndicator.SetActive(true);
        }
        else if (mapOpen)
        {
            mapOpen = false;
            //LocationButtons.SetActive(false);
            ButtonText.text = "To Map";
            MapCamera.SetActive(false);
            ARCamera.SetActive(true);
            PlayerIndicator.SetActive(false);
        }
    }
}
