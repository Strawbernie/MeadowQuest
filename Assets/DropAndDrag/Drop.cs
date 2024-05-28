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
                //Debug.Log("balls");
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
