using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drop : MonoBehaviour, IDropHandler
{
    [SerializeField]
    string CorrectName;
    public bool IsCorrect = false;
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
                if (draggable.name == CorrectName)
                {
                    IsCorrect = true;
                }
            }
        }
    }
    public void DestroyOld()
    {
        oldDraggable = newDraggable;
        if (oldDraggable != null)
        {
            Destroy(oldDraggable.gameObject);
        }
    }
    public void ResetIsCorrect()
    {
        IsCorrect = false;
    }
}
