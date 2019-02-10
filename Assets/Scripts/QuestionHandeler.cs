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
        if (activeQuestion)
        {
            if (!gameIsPaused)
            {
                StartCoroutine(TransissiontoNextQuestion(5f));
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        Debug.Log("resume game");
        questionMenu.SetActive(false);
        Time.timeScale = 1f;
        activeQuestion = false;
    }

    void Pause()
    {
        questionMenu.SetActive(true);
        Time.timeScale = 0f;
        activeQuestion = true;
    }

    public void QuitMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    IEnumerator TransissiontoNextQuestion(float waittime)
    {
        yield return new WaitForSeconds(waittime);
        Resume();
        gameIsPaused = true;
    }
}
