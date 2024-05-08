using System.Collections;
using System.Collections.Generic;
using Unity.Tutorials.Core.Editor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level1TutorialManager : MonoBehaviour, IPointerDownHandler
{
    public GameObject Map;
    public GameObject AR;
    public GameObject Ending;
    public GameObject MapCanvas;
    public GameObject ARCanvas;
    public GameObject TutorialCanvas;
    int tutorialStage;
    void Start()
    {
        if (LevelsUnlocked.TutorialUnlocked)
        {
        TutorialCanvas.SetActive(false);
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        tutorialStage++;
        if (!LevelsUnlocked.TutorialUnlocked)
        {
            switch (tutorialStage)
        {
            case 1:
                Ending.SetActive(false);
                Map.SetActive(true);
                break;
            case 2:
                Map.SetActive(false);
                AR.SetActive(true);
                break;
            case 3:
                AR.SetActive(false);
                Ending.SetActive(true);
                    MapCanvas.SetActive(false);
                    ARCanvas.SetActive(true);
                    break;
                    case 4:
                    LevelsUnlocked.TutorialUnlocked = true;
                    tutorialStage = 0;
                    Ending.SetActive(false);
                    SceneManager.LoadScene("Prototype1");
                    break;
            }
    }
        
        }
}
