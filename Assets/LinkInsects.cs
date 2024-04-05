using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LinkInsects : MonoBehaviour
{
    public bool inScene;
    public bool in2D;

    public void OnButtonPress()
    {
        if (inScene)
        {
            SceneManager.LoadScene("GPSAR");
        }
        else
        {
            SceneManager.LoadScene("LinkInsects");
        }
    }
    public void SwitchMap()
    {
        if (in2D)
        {
            SceneManager.LoadScene("3DGPSAR");
        }
        else
        {
            SceneManager.LoadScene("GPSAR");
        }
    }
}
