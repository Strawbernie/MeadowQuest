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
    [HideInInspector] public Vector3 startPosition;
    public Drop dropArea;
    private PinchToZoomAndShrink Pinch;
    public GameObject canvas;
    public string correctSection;
    [HideInInspector]
    public bool newSpawn;
    //public FlowerButton flowerButton;
    bool correct;
    bool dropped;
    FlowerGameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<FlowerGameManager>();
        Pinch = FindObjectOfType<PinchToZoomAndShrink>();
        //thisImage = GetComponent<Image>();
        startPosition = transform.position;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "DropArea"&& this.gameObject.tag == "DragOBJ")
        {
            transform.position = startPosition;
            GameObject prefab = FlowerPrefab;
            Drop drop = other.transform.gameObject.GetComponent<Drop>();
            if (drop.CorrectName == correctSection)
            {
                drop.IsCorrect = true;
                gameManager.checkWin();
            }
            else
            {
                drop.IsCorrect = false;
            }
            drop.DestroyOld();
                GameObject newFlower = Instantiate(prefab, other.transform.position, this.transform.rotation, other.transform);
                //newFlower.transform.localScale = new Vector3(Pinch.scrollRect.content.localScale.x / 3, Pinch.scrollRect.content.localScale.x / 3, Pinch.scrollRect.content.localScale.x / 3);
               // newFlower.transform.position = other.transform.position;
               // newFlower.gameObject.transform.SetParent(other.transform);
            }
            gameManager.ResetPositions();
            //newFlower.flowerButton = GetComponent<FlowerButton>();
            //flowerButton.resetButton();
            dropped = true;
    }
    void OnTriggerExit(Collider other)
    {
        dropped = false;
       gameManager.ResetPositions();
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
            gameManager.ResetPositions();
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

 


