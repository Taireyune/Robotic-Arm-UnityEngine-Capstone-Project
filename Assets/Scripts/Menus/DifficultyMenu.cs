using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultyMenu : MonoBehaviour
{
    ///
    /// Set difficulty and start game
    ///
    public void HandleHardButtonOnClickEvent()
    {
        ConfigData.SetDifficulty("hard");
        SceneManager.LoadScene("GamePlay");
        Destroy(gameObject);
    }

    public void HandleEasyButtonOnClickEvent()
    {
        ConfigData.SetDifficulty("easy");
        SceneManager.LoadScene("GamePlay");
        Destroy(gameObject);
    }
}
