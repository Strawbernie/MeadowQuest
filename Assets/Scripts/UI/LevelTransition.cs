using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour
{
    public string screenOrSceneName;
    [HideInInspector]
    public string finalName;

    public void OnButtonClickedGoToNextScreen()
    {
        SceneManager.LoadScene(finalName);
    }
}