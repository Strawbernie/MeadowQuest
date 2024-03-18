using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LinkInsects : MonoBehaviour
{
    public bool inScene;

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
}
