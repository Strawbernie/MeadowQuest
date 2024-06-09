using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class Gamemanager : MonoBehaviour
{
    void Awake()
    {
        Permission.RequestUserPermission(Permission.FineLocation);
        Permission.RequestUserPermission(Permission.Camera);
        Application.targetFrameRate = 30;
    }

}
