using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HelpMenu : MonoBehaviour
{
    public void HandleBackButtonOnClickEvent()
    {
        /// go to main menu if we are not in game play (pause window)
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            MenuManager.GoToMenu(MenuName.Main);
        }
        else if (SceneManager.GetActiveScene().name == "GamePlay")
        {
            MenuManager.GoToMenu(MenuName.Pause);
        }

        Destroy(gameObject);
    }
}
