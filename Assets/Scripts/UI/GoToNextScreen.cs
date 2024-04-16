using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GoToNextScreen : MonoBehaviour
{
    public string screenOrSceneName;
    [HideInInspector]
    public string baseString;

    public void Awake()
    {
        baseString = screenOrSceneName;
    }

    public void OnButtonClickedGoToNextScreen()
    {
        SceneManager.LoadScene(screenOrSceneName);
    }
}
