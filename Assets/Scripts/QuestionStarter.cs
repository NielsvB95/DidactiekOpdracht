using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestionStarter : MonoBehaviour {

    public DataManager dataManager;
    public GameObject Player;
    // Use this for initialization
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Player)
        {
            dataManager.SavePlayerPosition();
            SceneManager.LoadScene("Question");
        }
    }
}
