using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuizManager : MonoBehaviour
{
    public List<QuestionsAndAnswers> QnA;
    public GameObject[] options;
    public int currentQuestion;

    public TextMeshProUGUI QuestionTxt;


    private void Start()
    {
        //generates a question at the start
        generateQuestion();
    } 

    public void Correct()
    {
        //if the answer is correct then it generates a new question
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
    }

    public void Incorrect()
    {
        //if the answer is incorrect it stays with the current question
        
    }

    void SetAnswers()
    {
        // Ensure there are enough options for the answers provided
        if (QnA[currentQuestion].Answers.Count != options.Length)
        {
            Debug.LogError("Number of answers does not match number of options.");
            return;
        }

       for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].GetComponent<Image>().sprite = QnA[currentQuestion].Answers[i];
            options[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = ""; // Clear text

            if (QnA[currentQuestion].CorrectAnswer == i)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }

    //how it generates a new question
    void generateQuestion()
    {
        currentQuestion = Random.Range(0, QnA.Count);

        QuestionTxt.text = QnA[currentQuestion].Questions;
        SetAnswers();

  
    }

    [System.Serializable]
    public class QuestionsAndAnswers
    {
        public string Questions;
        public List<Sprite> Answers;
        public int CorrectAnswer;
    }
}
