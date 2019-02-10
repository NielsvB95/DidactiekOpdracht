using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownPlatform : MonoBehaviour {

    float platformSpeed = 2f;
    float startPoint;
    float endPoint;
    bool position;
    public int unitsToMove = 2;
    GameObject Player;
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        startPoint = transform.position.y;
        endPoint = startPoint + unitsToMove;
    }
    // Update is called once per frame
    void Update()
    {
        // the movement for the up down platform

        if (position)
        {
            transform.position += Vector3.up * platformSpeed * Time.deltaTime;
        }
        else
        {
            transform.position -= Vector3.up * platformSpeed * Time.deltaTime;
        }


        // the borders for the platform
        if (transform.position.y >= endPoint)
        {
            position = false;
        }
        if (transform.position.y <= startPoint)
        {
            position = true;
        }
    }
    // if the player hits on the platform
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player.transform.parent = transform;
        }
    }
    // if the player is not on the platform
    private void OnCollisionExit2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
            Player.transform.parent = null;
        }
    }

}
