﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour {

    /// <summary>Static reference to the instance of our DataManager</summary>
    public static DataManager instance;
    public GameObject Player;
    public static Vector3 playerPosition;

    public float playerPositionY;
    public float playerPositionX;

    private static string playerPositionKeyY = "PLAYER_POSITIONY";
    private static string playerPositionKeyX = "PLAYER_POSITIONX";

    /// <summary>Saves playerName, playerScore and 
    /// playerHealth to the PlayerPrefs file.</summary>
    public void SavePlayerPosition()
    {
        playerPosition = Player.transform.position;
        playerPositionX = playerPosition.x;
        playerPositionY = playerPosition.y;
        // Set the values to the PlayerPrefs file using their corresponding keys.
        PlayerPrefs.SetFloat(playerPositionKeyY, playerPosition.y);
        PlayerPrefs.SetFloat(playerPositionKeyX, playerPosition.x);

        // Manually save the PlayerPrefs file to disk, in case we experience a crash
        PlayerPrefs.Save();
        Debug.Log(playerPosition);
    }

    /// <summary>Saves playerName, playerScore and playerHealth 
    // from the PlayerPrefs file.</summary>
    public Vector3 LoadPlayer()
    {
        if (PlayerPrefs.HasKey(playerPositionKeyY) && PlayerPrefs.HasKey(playerPositionKeyX))
        {
            playerPosition = new Vector3(PlayerPrefs.GetFloat(playerPositionKeyX), PlayerPrefs.GetFloat(playerPositionKeyY), 0);
            // load playerPosition from the PlayerPrefs file.
            return playerPosition;
        }
        return playerPosition = new Vector3(0, 0, 0);
    }
}
