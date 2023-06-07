using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    EndScreen endScreen;
    Quiz quiz;
    StartScreen startScreen;

    // public bool playAgain = false;
    public bool StartScreen = false;

    void Start()
    {
        endScreen = FindObjectOfType<EndScreen>();
        quiz = FindObjectOfType<Quiz>();
        startScreen = FindObjectOfType<StartScreen>();
        startScreen.gameObject.SetActive(true);
        quiz.gameObject.SetActive(false);
        endScreen.gameObject.SetActive(false);
        
    }

    
    void Update()
    {
        if(StartScreen)
        {
            startScreen.gameObject.SetActive(false);
            quiz.gameObject.SetActive(true);
            endScreen.gameObject.SetActive(false);
        }
        if(quiz.isComplete == true)
        {
            startScreen.gameObject.SetActive(false);
            quiz.gameObject.SetActive(false);
            endScreen.gameObject.SetActive(true);
            endScreen.FinalScore();
        }
    }

    public void ReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        // playAgain = false;
    }
    // public void PlayAgain()
    // {
        // playAgain = true;
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    // }

    public void OnClick()
    {
        StartScreen = true;
    }
}
