using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    float scrollSpeed = -5f;
    Vector2 startPos;
    
    // Start is called before the first frame update
    void Start()
    {
        //startPos = Camera;
    }

    // Update is called once per frame
    void Update()
    {
        float newPos = Mathf.Repeat(Time.time * scrollSpeed, 20);
        transform.position = startPos + Vector2.up * newPos;
    }
}
