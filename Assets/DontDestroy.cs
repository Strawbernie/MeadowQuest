using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    public GameObject ArObjects;
    public GameObject Instruction;
    private void Update()
    {
        GameObject MapCamera = GameObject.Find("OrthographicCamera");
     if(ArObjects.activeSelf || MapCamera!=null)
        {
            Instruction.SetActive(false);
        }
        else
        {
            Instruction.SetActive(true);
        }
    }

}
