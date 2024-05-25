using UnityEngine;

public class AnswerScript : MonoBehaviour
{
    public bool isCorrect = false;
    private QuizManager quizManager;

    private void Start()
    {
        quizManager = FindObjectOfType<QuizManager>();
    }

    public void Answer()
    {
        if (isCorrect)
        {
            quizManager.Correct();
        }
        else
        {
            quizManager.Incorrect();
        }
    }
}
