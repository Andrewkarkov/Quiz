using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "New Question", fileName = "Question")]

public class QuestionSO : ScriptableObject
{
    [TextArea(2,4)]
    [SerializeField] string question = "My new answer";
    [SerializeField] string[] answer = new string[4];
    [SerializeField]int correctAnswerIndex; 

    public string GetQuestion()
    {
        return question;
    }
    public string GetAnswer(int index)
    {
        return answer[index];
    }
    public int GetCorrectAnswerIndex()
    {
        return correctAnswerIndex;
    }

}
