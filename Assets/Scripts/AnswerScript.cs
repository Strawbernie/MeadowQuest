using UnityEngine;

public class AnswerScript : MonoBehaviour
{
    public bool isCorrect = false;
    private QuizManager quizManager;
    public GameObject correctImage;
    public GameObject incorrectImage;

    private void Start()
    {
        quizManager = FindObjectOfType<QuizManager>();
    }

    public void Answer()
    {
        if (isCorrect)
        {
            quizManager.Correct();
            //If the question is correct the correct image will show ontop
            correctImage.SetActive(true);
        }
        else
        {
            //If the question is incorrect the incorrect image will show ontop
            incorrectImage.SetActive(true);
        }
    }
}
