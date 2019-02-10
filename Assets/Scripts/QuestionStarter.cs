using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestionStarter : MonoBehaviour {

    public GameObject dataManager;
    public GameObject Player;
    float VelY;
    Rigidbody2D rb;
    BoxCollider2D Hitbox;

    // get the last components
    private void Start()
    {
        Hitbox = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        VelY = rb.velocity.y;
    }

    void Awake()
    {
        dataManager = GameObject.FindGameObjectWithTag("DataManager");
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    // if the player passes a question gameobject/prefab
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == Player)
        {
            StartCoroutine(StartQuestion(1f));
        }
    }

    // wait for the player to start the question 
    IEnumerator StartQuestion(float waittime)
    {
        yield return new WaitForSeconds(waittime);
        Hitbox.isTrigger = false;
        QuestionHandeler.activeQuestion = true; // goes to the question manager
        dataManager.GetComponent<DataManager>().SavePlayerPosition();// saves the position of the player
    }
}
