using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestionSetupCompe : MonoBehaviour
{
    [SerializeField]
    public List<QuestionData> questions;
    private QuestionData currentQuestion;

    [SerializeField]
    private TextMeshProUGUI questionTextCompe;
    [SerializeField]
    private TextMeshProUGUI categoryTextCompe;
    [SerializeField]
    private AnswerButtonCompe[] answerButtonsCompe;

    [SerializeField]
    private int correctAnswerChoice;

    private string selectedCategory;

    private void Awake()
    {
        // Get the selected category from PlayerPrefs
        selectedCategory = PlayerPrefs.GetString("SelectedCategory", "Umum");

        // Get all the questions ready
        GetquestionAssets();
    }

    // Start is called before the first frame update
    public void Start()
    {
        // Filter questions based on the selected category
        //FilterquestionsByCategory();

        // Get a new question with Competitive Mode
        SelectNewQuestionCompe();

        // Set all text and values on screen
        SetQuestionValues();

        // Set all of the answer buttons text and correct answer values
        SetAnswerValues();
    }

    public void GetquestionAssets()
    {
        // Get all of the questions from the questions folder
        questions = new List<QuestionData>(Resources.LoadAll<QuestionData>("Pertanyaan"));
    }

    //private void FilterquestionsByCategory()
    //{
    //    questions = questions.FindAll(question => question.category == selectedCategory);
    //}



    private void SelectNewQuestionCompe()
    {
        string selectedCategory = "";

        if (selectedCategory == "Etnik")
        {
            // Filter the questions based on the selected category
            questions = questions.FindAll(question => question.category == selectedCategory);
        }
        else if (selectedCategory == "Cagar Alam")
        {
            // Filter the questions based on the selected category
            questions = questions.FindAll(question => question.category == selectedCategory);
        }
        else if (selectedCategory == "Kuliner")
        {
            // Filter the questions based on the selected category
            questions = questions.FindAll(question => question.category == selectedCategory);
        }
        else if (selectedCategory == "Budaya")
        {
            // Filter the questions based on the selected category
            questions = questions.FindAll(question => question.category == selectedCategory);
        }
        else if (selectedCategory == "Sejarah")
        {
            // Filter the questions based on the selected category
            questions = questions.FindAll(question => question.category == selectedCategory);
        }
        else if (selectedCategory == "Umum")
        {
            // Filter the questions based on the selected category
            questions = questions.FindAll(question => question.category == selectedCategory);
        }
        else if (selectedCategory == "Acak")
        {

            // Get a random value for which question to choose
            int randomquestionIndex = Random.Range(0, questions.Count - 1);

            // Set the question to the random index
            currentQuestion = questions[randomquestionIndex];

            // Remove this question from the list so it will not be repeated (until the game is restarted)
            questions.RemoveAt(randomquestionIndex);

        }
    }

    private void SetQuestionValues()
    {
        // Set the question text
        questionTextCompe.text = currentQuestion.question;
        // Set the category text
        categoryTextCompe.text = currentQuestion.category;
    }

    private void SetAnswerValues()
    {
        // Randomize the answer button order
        List<string> answers = RandomizeAnswers(new List<string>(currentQuestion.answers));

        // Set up the answer buttons
        for (int i = 0; i < answerButtonsCompe.Length; i++)
        {
            bool isCorrect = false;

            if (i == correctAnswerChoice)
            {
                isCorrect = true;
            }

            answerButtonsCompe[i].SetIsCorrect(isCorrect);
            answerButtonsCompe[i].SetAnswerText(answers[i]);
        }
    }

    private List<string> RandomizeAnswers(List<string> originalList)
    {
        bool correctAnswerChosen = false;
        List<string> newList = new List<string>();

        for (int i = 0; i < answerButtonsCompe.Length; i++)
        {
            int random = Random.Range(0, originalList.Count);

            if (random == 0 && !correctAnswerChosen)
            {
                correctAnswerChoice = i;
                correctAnswerChosen = true;
            }

            newList.Add(originalList[random]);
            originalList.RemoveAt(random);
        }

        return newList;
    }
}
