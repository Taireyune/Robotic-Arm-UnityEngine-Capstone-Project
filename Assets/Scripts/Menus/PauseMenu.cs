using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// Pauses and unpauses the game. Listens for the OnClick 
/// events for the pause menu buttons
public class PauseMenu : MonoBehaviour
{
    /// Use this for initialization
    void Start()
    {	
		// pause the game when added to the scene
		Time.timeScale = 0;
	}

	/// Handles the on click event from the Resume button
	public void HandleResumeButtonOnClickEvent()
    {
        // unpause game and destroy menu
        Time.timeScale = 1;
		Destroy(gameObject);
	}

	public void HandleHelpButtonOnClickEvent() 
	{
		MenuManager.GoToMenu(MenuName.Help);
		Destroy(gameObject);
	}

	/// Handles the on click event from the Quit button
	public void HandleQuitButtonOnClickEvent()
    {
        // AudioManager.Play(AudioClipName.MenuButtonClick);

        // unpause game, destroy menu, and go to main menu
        MenuManager.GoToMenu(MenuName.Main);
		Time.timeScale = 1;
		Destroy(gameObject);
	}
}
