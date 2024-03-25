using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropAss : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    { 
        if(eventData.pointerDrag.transform.tag == "DragOBJ" )
        {
            FailTryAgain draggable = eventData.pointerDrag.GetComponent<FailTryAgain>();
            if(draggable != null)
            {
                draggable.startPosition = transform.position;
            }
        }
    }
}
