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
                HandlePinchZoom();
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

    void HandlePinchZoom()
    {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

            float difference = currentMagnitude - prevMagnitude;

            Zoom(difference * zoomSpeed);
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

    void Zoom(float deltaMagnitudeDiff)
    {
        float newOrthographicSize = scrollRect.content.localScale.x + deltaMagnitudeDiff;

        // Clamp zoom within min and max zoom range
        newOrthographicSize = Mathf.Clamp(newOrthographicSize, minZoom, maxZoom);

        // Update the scroll rect's viewport size
        scrollRect.content.localScale = new Vector3(newOrthographicSize, newOrthographicSize, 1f);
    }
}