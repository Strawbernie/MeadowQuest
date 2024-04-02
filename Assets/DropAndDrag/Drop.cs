using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drop : MonoBehaviour, IDropHandler
{
    [SerializeField]
    string CorrectName;
    public bool IsCorrect = false;
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null && eventData.pointerDrag.CompareTag("DragOBJ"))
        {
            FailTryAgain draggable = eventData.pointerDrag.GetComponent<FailTryAgain>();
            if (draggable != null)
            {
                draggable.startPosition = transform.position;
                if (draggable.name == CorrectName)
                {
                    IsCorrect = true;
                }
            }
        }
    }
    public void ResetIsCorrect()
    {
        IsCorrect = false;
    }
}
