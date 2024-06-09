using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerGameManager : MonoBehaviour
{
    public Drop dropSection1;
    public Drop dropSection2;
    public Drop dropSection3;
    public GameObject winCanvas;
    public FailTryAgain[] listElements;

    public void checkWin()
    {
        if (dropSection1.IsCorrect &&  dropSection2.IsCorrect && dropSection3.IsCorrect)
        {
            winCanvas.SetActive(true);
        }
    }
    public void ResetPositions()
    {
        foreach (var element in listElements)
        {
            element.gameObject.transform.position = element.startPosition;
        }
    }
}
