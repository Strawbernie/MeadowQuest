using AirFishLab.ScrollingList;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;


public class FailTryAgain : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public GameObject FlowerPrefab;
    //public Image thisImage;
    private Vector3 startPosition;
    public Drop dropArea;
    private PinchToZoomAndShrink Pinch;
    public CircularScrollingList cList;
    public GameObject canvas;
    public string correctSection;
    [HideInInspector]
    public bool newSpawn;
    //public FlowerButton flowerButton;
    bool correct;
    bool dropped;

    void Start()
    {
        Pinch = FindObjectOfType<PinchToZoomAndShrink>();
        //thisImage = GetComponent<Image>();
        startPosition = transform.position;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "DropArea"&& this.gameObject.tag == "DragOBJ")
        {
            transform.position = startPosition;
            FailTryAgain prefab = FlowerPrefab.GetComponent<FailTryAgain>();
            Drop drop = other.transform.gameObject.GetComponent<Drop>();
            if (drop.CorrectName == correctSection)
            {
                drop.IsCorrect = true;
            }
            else
            {
                drop.IsCorrect = false;
            }
            drop.DestroyOld();
            if (!newSpawn)
            {
                FailTryAgain newFlower = Instantiate(prefab, startPosition, this.transform.rotation, canvas.transform);
                newFlower.transform.localScale = new Vector3(Pinch.scrollRect.content.localScale.x / 3, Pinch.scrollRect.content.localScale.x / 3, Pinch.scrollRect.content.localScale.x / 3);
                newFlower.transform.position = other.transform.position;
                newFlower.gameObject.transform.SetParent(other.transform);
                newFlower.FlowerPrefab = FlowerPrefab;
                newFlower.dropArea = dropArea;
                newFlower.canvas = canvas;
                newFlower.cList = cList;
                newSpawn = true;
            }
            cList.GenerateBoxesAndArrange();
            //newFlower.flowerButton = GetComponent<FlowerButton>();
            //flowerButton.resetButton();
            dropped = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        dropped = false;
        cList.GenerateBoxesAndArrange();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        //thisImage.raycastTarget = false;
        Pinch.isDragging = true;
    }
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        Pinch.isDragging = false;
        if (!dropped)
        {
            transform.position = startPosition;
            cList.GenerateBoxesAndArrange();
        }
        if (newSpawn&&!dropped)
        {
            newSpawn = false;
        }
    }

    // Check if the draggable object is over the drop area
    private bool IsOverDropArea(RectTransform dropAreaRect)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(dropAreaRect, Input.mousePosition, null, out Vector2 localPoint);
        return dropAreaRect.rect.Contains(localPoint);
    }
}

 


