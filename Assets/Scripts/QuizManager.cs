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

    public Image QuestionImage; // Change from TextMeshProUGUI to Image
    public Slider progressBar;

    private int totalQuestions;

    public GameObject CorrectSign;
    public GameObject IncorrectSign;

    private void Start()
    {
        totalQuestions = QnA.Count;
        progressBar.maxValue = totalQuestions; // Set the max value of the progress bar
        progressBar.value = 0;

        // generates a question at the start
        generateQuestion();
    }

    public void Correct()
    {
        // if the answer is correct then it generates a new question
        QnA.RemoveAt(currentQuestion);
        progressBar.value++;
        generateQuestion();
    }

    public void Incorrect()
    {
        // if the answer is incorrect it stays with the current question

        IncorrectSign.SetActive(true);
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

    // how it generates a new question
   void generateQuestion()
    {
        currentQuestion = Random.Range(0, QnA.Count);

        QuestionImage.sprite = QnA[currentQuestion].QuestionSprite;
        SetAnswers();
        StartCoroutine(removeDelay()); 
    }
    IEnumerator removeDelay()
    {
        yield return new WaitForSeconds(.2f);
        foreach (GameObject option in options)
        {
            AnswerScript script = option.GetComponent<AnswerScript>();
            script.correctImage.SetActive(false);
            script.incorrectImage.SetActive(false);
        }
    }

    [System.Serializable]
    public class QuestionsAndAnswers
    {
        public Sprite QuestionSprite; // Changed from string to Sprite
        public List<Sprite> Answers;
        public int CorrectAnswer;
    }
}