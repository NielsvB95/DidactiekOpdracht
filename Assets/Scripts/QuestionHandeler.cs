using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestionHandeler : MonoBehaviour {

    
    public static bool activeQuestion = false;
    public static bool gameIsPaused = true;

    public GameObject questionMenu;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // check if menu is active
        if (activeQuestion)
        {
            // check if game is paused
            if (!gameIsPaused)
            {
                // start coroutine if the game is not paused (resume game)
                StartCoroutine(TransissiontoNextQuestion(5f));
            }
            else
            {
                // the game is paused
                Pause();
            }
        }
    }

    // resume the game
    public void Resume()
    {
        Debug.Log("resume game");
        questionMenu.SetActive(false);
        Time.timeScale = 1f;
        activeQuestion = false;
    }

    // pause the game
    void Pause()
    {
        questionMenu.SetActive(true);
        Time.timeScale = 0f;
        activeQuestion = true;
    }

    // wait to resume the game
    IEnumerator TransissiontoNextQuestion(float waittime)
    {
        yield return new WaitForSeconds(waittime);
        Resume();
        gameIsPaused = true;
    }
}
