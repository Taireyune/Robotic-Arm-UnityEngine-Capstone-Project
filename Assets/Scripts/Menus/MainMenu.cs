using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// Listens for the OnClick events for the main menu buttons
public class MainMenu : MonoBehaviour
{
	/// Handles the on click event from the play button
	public void HandlePlayButtonOnClickEvent()
    {
        // AudioManager.Play(AudioClipName.MenuButtonClick);
        MenuManager.GoToMenu(MenuName.Difficulty);

		// SceneManager.LoadScene("GamePlay");
	}

	// /// Handles the on click event from the high score button
	// public void HandleHighScoreButtonOnClickEvent()
    // {
    //     // AudioManager.Play(AudioClipName.MenuButtonClick);
    //     MenuManager.GoToMenu(MenuName.HighScore);
    // }

	/// Handles the on click event from the quit button
	public void HandleQuitButtonOnClickEvent()
    {
        // AudioManager.Play(AudioClipName.MenuButtonClick);
		print("quite");
        Application.Quit();
    }

	public void HandleHelpButtonOnClickEvent()
	{
		MenuManager.GoToMenu(MenuName.Help);
	}
} 
