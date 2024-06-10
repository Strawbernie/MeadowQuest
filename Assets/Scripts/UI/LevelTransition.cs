using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class LevelTransition : MonoBehaviour
{
    public string screenOrSceneName;
    [HideInInspector]
    public string finalName;
    public GameObject ComingSoon;

    public void OnButtonClickedGoToNextScreen()
    {
        if(Application.CanStreamedLevelBeLoaded(finalName))
        {
            SceneManager.LoadScene(finalName);
        }
        else
        {
            ComingSoon.SetActive(true);
            StartCoroutine(SetFalse());
        }
    }
    public IEnumerator SetFalse()
    {
        yield return new WaitForSeconds(1);
        ComingSoon.SetActive(false);
    }
}