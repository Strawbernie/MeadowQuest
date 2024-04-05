using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour
{
    Vector2 offset; // Changed to Vector2
    // The tag that the object will connect to
    public string destinationTag = "DropArea";

    void OnMouseDown()
    {
        offset = (Vector2)transform.position - MouseWorldPosition();
        GetComponent<Collider2D>().enabled = false; // Changed to Collider2D
    }

    void OnMouseDrag()
    {
        transform.position = (Vector2)MouseWorldPosition() + offset; // Changed to Vector2
    }

    void OnMouseUp()
    {
        var rayOrigin = Camera.main.transform.position;
        var rayDirection = (Vector2)MouseWorldPosition() - (Vector2)Camera.main.transform.position; // Changed to Vector2
        RaycastHit2D hitInfo = Physics2D.Raycast(rayOrigin, rayDirection); // Changed to RaycastHit2D for 2D physics
        if (hitInfo.collider != null && hitInfo.transform.tag == destinationTag) // Changed to Collider and RaycastHit2D
        {
            transform.position = hitInfo.transform.position;
        }
        GetComponent<Collider2D>().enabled = true; // Changed to Collider2D
    }

    Vector2 MouseWorldPosition() // Changed to Vector2
    {
        var mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return (Vector2)Camera.main.ScreenToWorldPoint(mouseScreenPos); // Changed to Vector2
    }
}