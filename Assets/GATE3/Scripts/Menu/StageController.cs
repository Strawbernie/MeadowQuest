using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;


public class StageController : MonoBehaviour
{
    public void Travel1stStage()
    {
        SceneManager.LoadScene("Stage1");
    }
    public void Travel2ndStage()
    {
        SceneManager.LoadScene("Stage2");
    }
    public void Travel3rdStage()
    {
        SceneManager.LoadScene("Stage3");
    }
    public void GoBack()
    {
        SceneManager.LoadScene("INTROSCREEN");
    }
}
