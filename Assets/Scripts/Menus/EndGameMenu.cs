using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGameMenu : MonoBehaviour
{
    public Text scoreDisplay;
    // string scoreText = "Your final score is {0}!";

    void Start() 
    {
        Time.timeScale = 0;
    }

    // public void FinalScore(float score) 
    // {
    //     scoreDisplay.text = string.Format(scoreText, score);
    // }  

    public void HandleQuitButtonOnClickEvent()
    {
        MenuManager.GoToMenu(MenuName.Main);
        Time.timeScale = 1;
        Destroy(gameObject);
    }
}
