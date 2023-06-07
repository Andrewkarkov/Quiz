using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartScreen : MonoBehaviour
{
    [SerializeField]TextMeshProUGUI startText;

    
    void Awake()    
    {
    
    }
    public void Start()
    {
        startText.text = "Welcome to \n QUIZ-I-COOL game!";
    }

    
    void Update()
    {
        
    }
}
