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
                // Hide the question panel or do other end-game logic
            }
        }
        else
        {
            // Wrong answer logic
            Debug.Log("Wrong answer! You lose.");
            // Show the lose panel
            // Assuming you have a GameObject reference for the lose panel in your script
           // losePanel.SetActive(true);
            // Here you can disable other UI elements, stop player movement, etc.
        }

        // Regardless of correct or wrong answer, you can disable the question panel
       // questionPanel.SetActive(false);
    }



    // Add other methods as needed
}
