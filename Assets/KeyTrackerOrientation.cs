/**
 * Script Name: KeyTrackerOrientation
 * Team: Mike, Bryant, Caleb
 * Description: Ensures the key tracker text is always located at the corner of the screen.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyTrackerOrientation : MonoBehaviour
{
    GameObject player;
    bool help_screen_on = false;

    // Start is called before the first frame update
    void Start()
    {
        // Makes the text visible.
        this.GetComponent<Renderer>().material.color = Color.black;
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("Player Fish");

        if (player != null)
        {
            Vector3 playerPos = player.transform.position;
            playerPos.x = player.transform.position.x + 6.5f;
            playerPos.y = player.transform.position.y - 4.0f;
            playerPos.z = -5.5f;

            this.transform.position = playerPos;
        }

        // Hides the text when the help screen is up.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (help_screen_on)
            {
                this.GetComponent<Renderer>().material.color = Color.black;
                help_screen_on = false;
            }
            else
            {
                this.GetComponent<Renderer>().material.color = Color.clear;
                help_screen_on = true;
            }
        }
    }
}
