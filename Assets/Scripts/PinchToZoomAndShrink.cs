using UnityEngine;
using UnityEngine.UI;

public class PinchToZoomAndShrink : MonoBehaviour
{
    public ScrollRect scrollRect;
    public float zoomSpeed = 0.1f;
    public float minZoom = 0.5f;
    public float maxZoom = 2f;

    public bool isDragging;
    private Vector2 prevTouchPos;
    private bool isZooming = false;

    void Update()
    {
        HandleInput();
    }

    void HandleInput()
    {
        if(!isDragging)
        {
            if (Input.touchCount == 2)
            {
                isZooming = true;
            }
            else if (Input.touchCount == 1 && !isZooming)
            {
                HandlePan();
            }
            else
            {
                isZooming = false;
            }
        }
    }


    void HandlePan()
    {
        Touch touch = Input.GetTouch(0);

        if (touch.phase == TouchPhase.Moved)
        {
            Vector2 touchDelta = touch.position - prevTouchPos;
            scrollRect.content.anchoredPosition += touchDelta;
        }

        prevTouchPos = touch.position;
    }
}