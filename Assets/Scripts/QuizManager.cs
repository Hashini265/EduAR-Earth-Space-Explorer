using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuizManager : MonoBehaviour
{
    public GameObject quizPanel;
    public TextMeshProUGUI quizTitle;
    public TextMeshProUGUI questionText;
    public TextMeshProUGUI feedbackText;
    public TextMeshProUGUI scoreText;

    public Button[] answerButtons;
    public Button nextButton;
    public Button restartButton;

    private string[] questions =
    {
        "Which planet is known as the Red Planet?",
        "Which planet do we live on?",
        "Which is the largest planet?",
        "Which planet is famous for its rings?",
        "What is Earth's natural satellite?"
    };

    private string[,] answers =
    {
        { "Earth", "Mars", "Jupiter", "Venus" },
        { "Mars", "Venus", "Earth", "Saturn" },
        { "Earth", "Mars", "Jupiter", "Mercury" },
        { "Venus", "Earth", "Saturn", "Mars" },
        { "Sun", "Moon", "Mars", "Jupiter" }
    };

    private int[] correctAnswers = { 1, 2, 2, 2, 1 };

    private int currentQuestion = 0;
    private int score = 0;
    private bool answered = false;

    void Start()
    {
        quizPanel.SetActive(false);
        restartButton.gameObject.SetActive(false);
        nextButton.gameObject.SetActive(false);

        for (int i = 0; i < answerButtons.Length; i++)
        {
            int index = i;
            answerButtons[i].onClick.AddListener(() => CheckAnswer(index));
        }

        nextButton.onClick.AddListener(NextQuestion);
        restartButton.onClick.AddListener(RestartQuiz);

        ShowQuestion();
    }

    void ShowQuestion()
    {
        answered = false;

        quizTitle.text = "EARTH QUIZ";
        questionText.text = questions[currentQuestion];
        feedbackText.text = "";

        scoreText.text = "Score: " + score + " / 5";

        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].gameObject.SetActive(true);
            answerButtons[i].interactable = true;

            answerButtons[i].GetComponentInChildren<TextMeshProUGUI>().text =
                answers[currentQuestion, i];
        }

        nextButton.gameObject.SetActive(false);
    }

    void CheckAnswer(int selectedAnswer)
    {
        if (answered)
            return;

        answered = true;

        if (selectedAnswer == correctAnswers[currentQuestion])
        {
            score++;
            feedbackText.text = "Correct Answer!";
        }
        else
        {
            feedbackText.text = "Incorrect! Correct answer: " +
                answers[currentQuestion, correctAnswers[currentQuestion]];
        }

        scoreText.text = "Score: " + score + " / 5";

        foreach (Button button in answerButtons)
            button.interactable = false;

        if (currentQuestion < questions.Length - 1)
            nextButton.gameObject.SetActive(true);
        else
        {
            feedbackText.text += "\nQuiz Completed!";
            restartButton.gameObject.SetActive(true);
        }
    }

    void NextQuestion()
    {
        currentQuestion++;
        ShowQuestion();
    }

    void RestartQuiz()
    {
        currentQuestion = 0;
        score = 0;

        restartButton.gameObject.SetActive(false);
        ShowQuestion();
    }
}