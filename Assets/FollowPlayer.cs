/**
 * Script Name: FollowPlayer
 * Team: Mike, Bryant, Caleb
 * Description: Script used to keep main camera fixed on player
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    GameObject player;//Variable for instance of player object in game space
    Vector3 playerPos;//Variable for player position coordinates

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("Player Fish");

        //If player is alive in game space
        if (player != null)
        {
            //Set camera to player position with a z axis offset of -10 (zooms camera out)
            playerPos = player.transform.position;
            playerPos.z = -10.0f;

            this.transform.position = playerPos;
        }


    }


}
