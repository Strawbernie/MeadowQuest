using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class NoPanArea : MonoBehaviour, IPointerDownHandler
{
    private PinchToZoomAndShrink Pinch;
    void Start()
    {
        Pinch = FindObjectOfType<PinchToZoomAndShrink>();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        Pinch.isDragging = true;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        Pinch.isDragging = false;
    }
}


