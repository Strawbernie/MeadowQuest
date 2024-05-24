using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drop : MonoBehaviour, IDropHandler
{
    public string CorrectName;
    public bool IsCorrect;
    FailTryAgain newDraggable;
    FailTryAgain oldDraggable;

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null && eventData.pointerDrag.CompareTag("DragOBJ"))
        {
            FailTryAgain draggable = eventData.pointerDrag.GetComponent<FailTryAgain>();
            if (draggable != null)
            {
                newDraggable = draggable;
                //draggable.startPosition = transform.position;
            }
        }
    }
    public void DestroyOld()
    {
        oldDraggable = newDraggable;
        foreach (Transform child in gameObject.transform)
        {
            Destroy(child.gameObject);
        }
        if (oldDraggable != null)
        {
            oldDraggable.newSpawn = false;
        }
    }
    public void ResetIsCorrect()
    {
        IsCorrect = false;
    }
}
