using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    public GameObject ArObjects;
    public GameObject Instruction;
    private void Update()
    {
     if(ArObjects.activeSelf)
        {
            Instruction.SetActive(false);
        }
        else
        {
            Instruction.SetActive(true);
        }
    }

}
