using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField]float TimeToCompleteQuestion = 30f;
    [SerializeField]float TimeToShowCorrectAnswer = 10f;
    
    public bool loadNextQuestion;
    public float fillFraction;
    public bool isAnsweringQuestion;

    
    float timeValue;

    void Update()
    {
        UpdateTimer();
    }

    public void CancelTimer()
    {
        timeValue = 0;
    }

    void  UpdateTimer()
    {
        timeValue -= Time.deltaTime;
        if(isAnsweringQuestion)
        {
            if(timeValue > 0)
            {
                fillFraction = timeValue / TimeToCompleteQuestion;
            }
            else
             {
                isAnsweringQuestion = false;
                timeValue = TimeToShowCorrectAnswer;
             }
        }
        else
        {
            if(timeValue > 0)
            {
                fillFraction = timeValue / TimeToShowCorrectAnswer;
            }
            else
            {
                isAnsweringQuestion = true;
                timeValue = TimeToCompleteQuestion;
                loadNextQuestion = true;
            }
        }
    }
}
