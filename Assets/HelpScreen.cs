/**
 * Script Name: HelpScreen
 * Team: Mike, Bryant, Caleb
 * Description: Lets the player bring up a help screen so that they can read the game's instructions.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpScreen : MonoBehaviour
{
    GameObject player;
    bool help_screen_on = false;

    // Start is called before the first frame update
    void Start()
    {
        // Initially, the help screen is invisible.
        this.GetComponent<Renderer>().material.color = Color.clear;
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("Player Fish");

        if (player != null)
        {
            Vector3 playerPos = player.transform.position;
            playerPos.z = -5.5f;

            this.transform.position = playerPos;
        }

        // When the space key is pressed, pause the game and bring up the help screen.
        // When the space key is pressed again, unpause the game and remove the help screen.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (help_screen_on)
            {
                this.GetComponent<Renderer>().material.color = Color.clear;
                Time.timeScale = 1;
                help_screen_on = false;
            }
            else
            {
                this.GetComponent<Renderer>().material.color = Color.black;
                Time.timeScale = 0;
                help_screen_on = true;
            }
        }
    }
}
