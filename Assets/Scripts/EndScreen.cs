using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class EndScreen : MonoBehaviour
{
    [SerializeField]TextMeshProUGUI endText;
    ScoreKeeper scoreKeeper;

    void Awake()    
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    public void FinalScore()
    {
        endText.text = "Congratulations! \n You score" + scoreKeeper.CalculateScore() + "%";
    }

}
