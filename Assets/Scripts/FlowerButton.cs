using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class FlowerButton : MonoBehaviour
{
    public FailTryAgain FlowerPrefab;
    public Drop CorrectDropArea;
    Button button;
    private PinchToZoomAndShrink Pinch;

    private void Start()
    {
       button = GetComponent<Button>();
        Pinch = FindObjectOfType(typeof(PinchToZoomAndShrink)) as PinchToZoomAndShrink;
    }
    public void OnButtonPress()
    {
        FailTryAgain newFlower = Instantiate(FlowerPrefab, this.transform.position, this.transform.rotation, this.transform);
        newFlower.transform.localScale = new Vector3(Pinch.scrollRect.content.localScale.x/3, Pinch.scrollRect.content.localScale.x / 3, Pinch.scrollRect.content.localScale.x / 3);
        newFlower.dropArea = CorrectDropArea;
        newFlower.flowerButton = GetComponent<FlowerButton>();
        button.interactable = false;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        Pinch.isDragging = true;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        Pinch.isDragging = false;
    }
    public void resetButton()
    {
        button.interactable = true;
    }
}
