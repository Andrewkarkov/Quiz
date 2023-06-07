using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{ 
    [Header("Questions")]
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField]List<QuestionSO> questions = new List<QuestionSO>();
    QuestionSO currentQuestion;

    [Header("Answers")]
    [SerializeField] GameObject[] answerButton;
    bool hasAnsweredEarly;

    [Header("Button Sprite")]
    [SerializeField] Sprite defoultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;

    [Header("Timer")]
    [SerializeField]Image timerImage;
    Timer timer;

    [Header("Scoring")]
    [SerializeField]TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;

    [Header("ProgressBar")]
    [SerializeField]Slider progressBar;

    public bool isComplete;
    int correctAnswerIndex;

    void Start()
    { 
        timer = FindObjectOfType<Timer>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        FirstQuestion();
        progressBar.maxValue = questions.Count;
        progressBar.value = 0;
        
    }
    void Update() 
    {
        timerImage.fillAmount = timer.fillFraction;
        if(timer.loadNextQuestion)
        {
            if(progressBar.value == progressBar.maxValue)
            {
                isComplete = true;
                return;
            }
            hasAnsweredEarly = false;
            GetNextQuestion();
            timer.loadNextQuestion = false;
        }
        else if(!hasAnsweredEarly && !timer.isAnsweringQuestion)
        {
            DisplayAnswer(-1);
            SetButtonState(false);
        }
    }

    void FirstQuestion()
    {
       int index = Random.Range(0, questions.Count);
       currentQuestion = questions[index];
    }

    void DisplayQuestion()
    {
        questionText.text = currentQuestion.GetQuestion();
        for(int i = 0; i < answerButton.Length; i++)
        {
            TextMeshProUGUI buttonText = answerButton[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = currentQuestion.GetAnswer(i);
        }
    }
    void SetButtonState(bool state)
    {
        for(int i = 0; i < answerButton.Length; i++)
        {
        Button button = answerButton[i].GetComponent<Button>();
        button.interactable = state;
        }
    }
    void SetDefaultButtonSprites()
    {
        for(int i = 0; i < answerButton.Length; i++)
            {
            Image buttonImage = answerButton[i].GetComponent<Image>();
            buttonImage.sprite = defoultAnswerSprite;
            }
    }
    void GetNextQuestion()
    {
        if(questions.Count > 0)
        {
            SetButtonState(true);
            SetDefaultButtonSprites();
            GetRandomQuestion();
            DisplayQuestion();
            scoreKeeper.IncrementQuestionSeen();
            progressBar.value++;
        } 
    }

    void GetRandomQuestion()
    {
        FirstQuestion();
        if(questions.Contains(currentQuestion))
        {
            questions.Remove(currentQuestion);    
        }
        
    }

    public void OnAnswerSelected(int index)
    {
        hasAnsweredEarly = true;
        DisplayAnswer(index);
        SetButtonState(false);
        timer.CancelTimer();
        scoreText.text = "Score: " + scoreKeeper.CalculateScore() + "%";
       
    }
    public void DisplayAnswer(int index)
    {
        Image buttonImage;
        if(index == currentQuestion.GetCorrectAnswerIndex())
        {
            questionText.text = "Correct!";
            buttonImage = answerButton[index].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
           scoreKeeper.IncrementCorrectAnswer();
        }
        else
        {
            correctAnswerIndex = currentQuestion.GetCorrectAnswerIndex();
            string correctAnswer = currentQuestion.GetAnswer(correctAnswerIndex);
            questionText.text = "Sorry, the correct answer was \n" + correctAnswer; 
            buttonImage = answerButton[correctAnswerIndex].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }
    }


}
