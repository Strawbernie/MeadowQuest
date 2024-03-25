using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class FailTryAgain : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public Image thisImage;
    public Vector3 startPosition;

    void Start()
    {
        thisImage = GetComponent<Image>();
        startPosition = transform.position;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        thisImage.raycastTarget = false;
    }
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        transform.position = startPosition;
        thisImage.raycastTarget = true;
    }
}
 


