using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestionStarter : MonoBehaviour {

    public GameObject dataManager;
    public GameObject Player;

    // Use this for initialization
    public void OnCollisionEnter2D(Collision2D collision)
    {
        dataManager = GameObject.FindGameObjectWithTag("DataManager");
        Player = GameObject.FindGameObjectWithTag("Player");
        Debug.Log("The player object contains" + Player);
        if (collision.gameObject == Player)
        {
            Debug.Log("There is a collision");
            dataManager.GetComponent<DataManager>().SavePlayerPosition();

        }
    }
}
