using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelButtonsScript : MonoBehaviour
{
    public string levelName;

    public void OnLevelButtonClicked()
    {
        SceneManager.LoadScene(levelName);
    }
}
