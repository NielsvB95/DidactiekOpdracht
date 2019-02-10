using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausemenu : MonoBehaviour {

    public static bool gameIsPaused = false;

    public GameObject pauseMenuUI;

    void Update () {
        // if the player presses the escape button the game will be paused
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // if the game is not paused the game continues
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
	}

    // resume the game
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    // pause the game
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    // quit the game
    public void QuitMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}   
