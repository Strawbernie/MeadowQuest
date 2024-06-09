using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class ARManager : MonoBehaviour
{
    public GameObject ARObject;
    private void Awake()
    {
        if (!LevelsUnlocked.ARUnlocked)
        {
            ARObject.SetActive(true);
            DontDestroyOnLoad(ARObject);
            LevelsUnlocked.ARUnlocked = true;
        }
        else
        {
            ARObject.SetActive(false);
        }
    }
}
