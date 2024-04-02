using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEndChecker : MonoBehaviour
{
    [SerializeField]
    Drop Sprite1;
    [SerializeField]
    Drop Sprite2;
    [SerializeField]
    Drop Sprite3;
    [SerializeField]
    Drop Sprite4;
    [SerializeField]
    GameObject WinScreen;

    private void Update()
    {
        
            if (Sprite1.IsCorrect == true &&
                Sprite2.IsCorrect == true &&
                Sprite3.IsCorrect == true &&
                Sprite4.IsCorrect == true)
            {
             WinScreen.SetActive(true);
            }
        

    }

    public void SendMeBack()
    {
        //SceneManager.LoadScene(Write this stuff)
        //This shit also should trigger a bool that after will be checked on the main screen and change the lay-out
    }
    


  
}
