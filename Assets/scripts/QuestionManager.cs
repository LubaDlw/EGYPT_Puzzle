using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestionManager : MonoBehaviour
{
    public TMP_Text questionText;
    public Button[] answerButtons;
    public PlayerController playerController;
    public List<RiddleQuestion> questions;
    private int currentQuestionIndex = 0;

    private void Start()
    {

        DisplayQuestion(currentQuestionIndex);
    }

    private void DisplayQuestion(int questionIndex)
    {
        if (questionIndex < questions.Count)
        {
            RiddleQuestion currentQuestion = questions[questionIndex];
            questionText.text = currentQuestion.question;

            for (int i = 0; i < answerButtons.Length; i++)
            {
                answerButtons[i].GetComponentInChildren<TMP_Text>().text = currentQuestion.answers[i];
                Debug.Log("Button " + i + " text: " + currentQuestion.answers[i]);
            }
        }
        else
        {
            // Handle end of questions
        }
    }

    public void AnswerButtonClicked(int selectedAnswerIndex)
    {
        RiddleQuestion currentQuestion = questions[currentQuestionIndex];

        if (selectedAnswerIndex == currentQuestion.correctAnswerIndex)
        {
            // This is the logic for the correct answer
            Debug.Log("Correct answer!");

            currentQuestionIndex++;
            if (currentQuestionIndex < questions.Count)
            {
                DisplayQuestion(currentQuestionIndex);
            }
            else
            {
                Debug.Log("All questions answered!");
                playerController.riddleCanvas.SetActive(false);
                // win function
            }
        }
        else
        {
            // Wrong answer logic + LosePanel
            Debug.Log("Wrong answer! You lose.");
            playerController.losePanel.SetActive(true);
            
            // add logic to restart scene after 5 seconds
           
        }

        
       // questionPanel.SetActive(false);
    }



   
}
