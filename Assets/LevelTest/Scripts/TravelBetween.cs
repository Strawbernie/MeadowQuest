using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TravelBetween : MonoBehaviour
{
  public void ToNextScene()
    {
        SceneManager.LoadScene("Level2");
    }
   
    public void GoBack()
    {
        SceneManager.LoadScene("Level1");
    }
}
