using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour, IPointerDownHandler
{
    public GameObject Tutorial;
    public GameObject Intro;
    public GameObject Levels;
    public GameObject Sections;
    public GameObject ARButton;
    public GameObject Map;
    public GameObject Encyclopedia;
    public GameObject canvasEncyclopedia;
    public GameObject canvasMain;
    public GameObject canvasMain1;
    int tutorialStage;

    public void OnPointerDown(PointerEventData eventData)
    {
        tutorialStage++;
        if (!LevelsUnlocked.TutorialUnlocked)
        {
            switch (tutorialStage)
            {
                case 0:
                    Map.SetActive(false);
                    Intro.SetActive(true);
                    break;
                case 1:
                    Intro.SetActive(false);
                    Levels.SetActive(true);
                    break;
                case 2:
                    Levels.SetActive(false);
                    Sections.SetActive(true);
                    canvasEncyclopedia.SetActive(true);
                    canvasMain.SetActive(false);
                    canvasMain1.SetActive(false);
                    break;
                case 3:
                    Sections.SetActive(false);
                    ARButton.SetActive(true);
                    canvasEncyclopedia.SetActive(false);
                    canvasMain.SetActive(true);
                    canvasMain1.SetActive(true);
                    break;
                case 4:
                    ARButton.SetActive(false);
                    Map.SetActive(true);
                    break;
                case 5:
                    tutorialStage = 0;
                    SceneManager.LoadScene("Stage1Flower");
                    break;
            }
        }
    }

}
