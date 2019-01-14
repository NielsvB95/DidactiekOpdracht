using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGui2D : MonoBehaviour {

    public static int score;
    private GUIStyle guiStyle = new GUIStyle(); 

    void Start () {
        score = 0;
	}

    void OnGUI()
    {
        guiStyle.fontSize = 50; //change the font size
        GUI.Label(new Rect(0, 0, 100, 0), "Score: " + score, guiStyle);    
    }

}
