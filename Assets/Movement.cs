/**
 * Script Name: Movement
 * Team: Mike, Bryant, Caleb
 * Description: Enables player movement via arrows keys on keyboard
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movement : MonoBehaviour
{
    bool up;//Case for up move
    bool down;//Case for down move
    bool left;//Case for left move
    bool right;//Case for right move

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //Resetting move cases
        up = false;
        down = false;
        left = false;
        right = false;


        //Acquiring user input, also checking if player has reached a boundary in the world space
        if (Input.GetKey(KeyCode.LeftArrow) && this.transform.position.x > -50.3f)//Left boundary
        {
            Vector3 position = this.transform.position;
            position.x-= 0.1f;
            this.transform.position = position;
            left = true;
        }
        if (Input.GetKey(KeyCode.RightArrow) && this.transform.position.x < 40.1f)//Right boundary
        {
            Vector3 position = this.transform.position;
            position.x+= 0.1f;
            this.transform.position = position;
            right = true;
        }
        if (Input.GetKey(KeyCode.UpArrow) && this.transform.position.y < 64.5f)//Up boundary
        {
            Vector3 position = this.transform.position;
            position.y+= 0.1f;
            this.transform.position = position;
            up = true;
        }
        if (Input.GetKey(KeyCode.DownArrow) && this.transform.position.y > -27.8f)//Down boundary
        {
            Vector3 position = this.transform.position;
            position.y-= 0.1f;
            this.transform.position = position;
            down = true;
        }

        //Setting rotation of player
        SetPosition();
    }

    //Adjusts rotation of player according to movement in game space
    void SetPosition()
    {
        if (up && right)
        {
            this.transform.eulerAngles = new Vector3(-135.0f, -90.0f, 90.0f);
        }
        else if (up && left)
        {
            this.transform.eulerAngles = new Vector3(-135.0f, 90.0f, -90.0f);
        }
        else if (down && right)
        {
            this.transform.eulerAngles = new Vector3(-225.0f, -90.0f, 90.0f);
        }
        else if (down && left)
        {
            this.transform.eulerAngles = new Vector3(-225.0f, 90.0f, -90.0f);
        }
        else if (up)
        {
            this.transform.eulerAngles = new Vector3(-90.0f, 0.0f, 0.0f);
        }
        else if(down)
        {
            this.transform.eulerAngles = new Vector3(-270.0f, -90.0f, 90.0f);
        }
        else if(left)
        {
            this.transform.eulerAngles = new Vector3(-180.0f, 90.0f, -90.0f);
        }
        else if(right)
        {
            this.transform.eulerAngles = new Vector3(-180.0f, -90.0f, 90.0f);
        }

    }
}
