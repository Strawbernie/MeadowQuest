using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapButton : MonoBehaviour
{
    public GameObject canvasTrue;
    public GameObject canvasFalse1;
    public GameObject canvasFalse2;
    public void OnButtonPress()
    {
            canvasTrue.SetActive(true);
            canvasFalse1.SetActive(false);
            canvasFalse2.SetActive(false);
    }
}
