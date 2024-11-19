using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class AnswerButtonCompe : MonoBehaviour
{
    private bool isCorrect;
    [SerializeField] private TextMeshProUGUI answerText;

    // To make it ask a new question after the first question
    [SerializeField] private QuestionSetupCompe questionSetupCompe;

    // Reference to the CountdownTimer
    [SerializeField] private TimerCountdownCompe countdownTimer;

    // TextMeshProUGUI element to display the score
    [SerializeField] private TextMeshProUGUI scoreText;

    public int score = 0;

    public void SetAnswerText(string newText)
    {
        answerText.text = newText;
    }

    public void SetIsCorrect(bool newBool)
    {
        isCorrect = newBool;
    }

    public void OnClick()
    {
        if (isCorrect)
        {
            score += 1000;
            Debug.Log("Jawaban Benar, bertambah 1000 poin");
            SceneManager.LoadScene("GameArea");
        }
        else
        {
            score -= 500;
            Debug.Log("Jawaban Salah, berkurang 500 poin");
            SceneManager.LoadScene("GameArea");
        }

        // Update the score display
        UpdateScoreText();

        // Get the next question if there are more in the list
        if (questionSetupCompe.questions.Count > 0)
        {
            // Generate a new question
            questionSetupCompe.Start();
        }
    }

    private void UpdateScoreText()
    {
        scoreText.text = score.ToString("D5"); // D5 format for leading zeros
    }
}
