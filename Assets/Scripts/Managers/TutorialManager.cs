using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
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
    public GameObject Settings;
    public GameObject Ending;
    int tutorialStage;

    public void OnPointerDown(PointerEventData eventData)
    {
            tutorialStage++;
        switch (tutorialStage)
        {
            case 0:
                Ending.SetActive(false);
                Intro.SetActive(true);
                break;
            case 1:
                Intro.SetActive(false);
                Levels.SetActive(true);
                break;
            case 2:
                Levels.SetActive(false);
                Sections.SetActive(true);
                break;
            case 3:
                Sections.SetActive(false);
                ARButton.SetActive(true);
                break;
            case 4:
                ARButton.SetActive(false);
                Map.SetActive(true);
                break;
            case 5:
                Map.SetActive(false);
                Encyclopedia.SetActive(true);
                break;
            case 6:
                Encyclopedia.SetActive(false);
                Settings.SetActive(true);
                break;
            case 7:
                Settings.SetActive(false);
                Ending.SetActive(true);
                break;
            case 8:
                LevelsUnlocked.TutorialUnlocked = true;
                tutorialStage = 0;
                Ending.SetActive(false);
                Intro.SetActive(true);
                Tutorial.SetActive(false);
                break;
        }
    }

}
