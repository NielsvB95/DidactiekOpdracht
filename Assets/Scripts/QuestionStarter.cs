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
    /*
    // Use this for initialization
    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("The player object contains" + Player);
        if (collision.gameObject == Player)
        {
            QuestionHandeler.activeQuestion = true;
            dataManager.GetComponent<DataManager>().SavePlayerPosition();
        }
    }
    */
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == Player)
        {
            StartCoroutine(StartQuestion(1f));
        }
    }

    IEnumerator StartQuestion(float waittime)
    {
        yield return new WaitForSeconds(waittime);
        Hitbox.isTrigger = false;
        QuestionHandeler.activeQuestion = true;
        dataManager.GetComponent<DataManager>().SavePlayerPosition();
    }
}
