using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/// Manages navigation through the menu system
public static class MenuManager
{
	/// Goes to the menu with the given name
	public static void GoToMenu(MenuName name)
    {
        switch (name)
        {
            case MenuName.Main:
                // go to MainMenu scene
                SceneManager.LoadScene("MainMenu");
                break;

            case MenuName.Pause:
                // instantiate prefab
                Object.Instantiate(Resources.Load(@"Menus/PauseMenu"));
                break;

            case MenuName.Help:
                // open help menu
                GameObject mainMenu = GameObject.Find("MainMenu");
                GameObject pauseMenu = GameObject.Find("PauseMenu");
                if (mainMenu != null) 
                {
                    mainMenu.SetActive(false);
                }
                if (pauseMenu != null)
                {
                    pauseMenu.SetActive(false);
                }
                Object.Instantiate(Resources.Load(@"Menus/HelpMenu"));
                break;

            case MenuName.Difficulty:
                /// hide main menu
                mainMenu = GameObject.Find("MainMenu");
                if (mainMenu != null) 
                {
                    mainMenu.SetActive(false);
                }
                /// go to difficulty menu 
                Object.Instantiate(Resources.Load(@"Menus/DifficultyMenu"));
                break;

            case MenuName.GameWon:
                Object.Instantiate(Resources.Load(@"Menus/GameWonMenu"));
                break;

            case MenuName.GameOver:
                Object.Instantiate(Resources.Load(@"Menus/GameOverMenu"));
                break;
        }
	}
}
