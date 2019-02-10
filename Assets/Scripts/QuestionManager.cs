using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class QuestionManager : MonoBehaviour
{
    public Question[] questions;
    private static List<Question> unanswerdQuestions;

    private Question currentQuestion;

    public GameObject questionMenu;

    public bool answerd = false;

    [SerializeField]
    private Text factText;

    [SerializeField]
    private float timeBetweenQuestions = 1f;

    private void Awake()
    {
        unanswerdQuestions = questions.ToList<Question>();
    }
    void Start()
    {
        if (unanswerdQuestions == null || unanswerdQuestions.Count == 0)
        {
            Endgamemenu.endGame = true;
        }
        SetCurrentQuestion();
    }

    void Update()
    {
        if (answerd)
        {
            unanswerdQuestions.Remove(currentQuestion);
            if (unanswerdQuestions == null || unanswerdQuestions.Count == 0)
            {
                unanswerdQuestions = questions.ToList<Question>();
            }
            SetCurrentQuestion();
            QuestionHandeler.gameIsPaused = false;
            answerd = false;
        }
    }

    void SetCurrentQuestion()
    {
        int randomQuestionIndex = Random.Range(0, unanswerdQuestions.Count);
        currentQuestion = unanswerdQuestions[randomQuestionIndex];

        factText.text = currentQuestion.fact;
    }

    

    public void UserSelectTrue()
    {
        if (currentQuestion.istrue)
        {
            OnGui2D.score -= 20;
            Debug.Log("Het antwoord is goed");
        }
        else
        {
            OnGui2D.score += 20;
            Debug.Log("Het antwoord is fout");
        }
        Time.timeScale = 1f;
        answerd = true;

    }
    public void UserSelectFalse()
    {
        if (!currentQuestion.istrue)
        {
            OnGui2D.score -= 20;
            Debug.Log("Het antwoord is goed");
        }
        else
        {
            OnGui2D.score += 20;
            Debug.Log("Je hebt het antwoord fout");
        }
        Time.timeScale = 1f;
        answerd = true;
    }
}
