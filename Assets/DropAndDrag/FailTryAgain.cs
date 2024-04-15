using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class FailTryAgain : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public Image thisImage;
    private Vector3 startPosition;
    public Drop dropArea;
    private PinchToZoomAndShrink Pinch;
    public FlowerButton flowerButton;
    bool correct;
    bool dropped;

    void Start()
    {
        Pinch = FindObjectOfType<PinchToZoomAndShrink>();
        thisImage = GetComponent<Image>();
        startPosition = transform.position;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "DropArea")
        {
            Drop drop = other.transform.gameObject.GetComponent<Drop>();
            drop.DestroyOld();
            this.gameObject.transform.SetParent(other.transform);
            transform.position = other.transform.position;
            startPosition = other.transform.position;
            flowerButton.resetButton();
            dropped = true;
        }
        if (other.gameObject.GetComponent<Drop>() == dropArea)
        {
            correct = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Drop>() == dropArea)
        {
            correct = false;
        }
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        thisImage.raycastTarget = false;
        Pinch.isDragging = true;
    }
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        Pinch.isDragging = false;
        if (!correct)
        {
            transform.position = startPosition;
        }
    }

    // Check if the draggable object is over the drop area
    private bool IsOverDropArea(RectTransform dropAreaRect)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(dropAreaRect, Input.mousePosition, null, out Vector2 localPoint);
        return dropAreaRect.rect.Contains(localPoint);
    }
}

 


