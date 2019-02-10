using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Endgamemenu : MonoBehaviour
{

    public static bool endGame = false;
    public Text score;

    public GameObject endGameMenu;
    // Update is called once per frame
    void Update()
    {
        if (endGame)
        {
            score.text = OnGui2D.score.ToString();
            Pause();
        }
    }
    
    void Pause()
    {
        endGameMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void QuitMenu()
    {
        Time.timeScale = 1f;
        endGame = false;
        SceneManager.LoadScene("Menu");
    }
}
