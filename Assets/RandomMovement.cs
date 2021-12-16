/**
 * Script Name: RandomMovement
 * Team: Mike, Bryant, Caleb
 * Description: Script used for random NPC fish movement.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    int moveValue;//Determines which direction object will move
    bool cooldown;//Allows object movement to change over specfifed amount of time
    Vector3 position;//Saves object position
    bool pastLeft;//Left barrier check
    bool pastRight;//Right barrier check
    bool pastUp;//Up barrier check
    bool pastDown;//Down barrier check
    //Values for movement direction
    enum movementMode
    {
        Up,         // 0
        Down,       // 1
        Left,       // 2
        Right,      // 3
        UpRight,    // 4
        UpLeft,     // 5
        DownLeft,   // 6
        DownRight   // 7
    }

    // Start is called before the first frame update
    void Start()
    {
        cooldown = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Generating a movement mode
        if (!cooldown)
            moveValue = (int) ((UnityEngine.Random.value * (0.7999f))*10.0f);


        //Checking if object posiition is past the defined barriers in-game
        position = this.transform.position;
        pastLeft = position.x <= -50.3f;
        pastRight = position.x >= 40.1f;
        pastUp = position.y >= 64.5f;
        pastDown = position.y <= -27.8f;

        if (moveValue == (int)movementMode.Left && pastLeft)//If moving left past left barrier, switch to right movement
        {
            moveValue = (int)movementMode.Right;
        }
        if (moveValue == (int)movementMode.Right && pastRight)//If moving right past right barrier, switch to left movement
        {
            moveValue = (int)movementMode.Left;
        }
        if (moveValue == (int)movementMode.Up && pastUp)//If moving up past up barrier, switch to down movement
        {
            moveValue = (int)movementMode.Down;
        }
        if (moveValue == (int)movementMode.Down && pastDown)//If moving down past down barrier, switch to up movement
        {
            moveValue = (int)movementMode.Up;
        }
        if (moveValue == (int)movementMode.UpLeft && (pastLeft || pastUp))//If moving up-left past left barrier or up barrier, switch to down-right movement
        {
            moveValue = (int)movementMode.DownRight;
        }
        if (moveValue == (int)movementMode.UpRight && (pastRight || pastUp))//If moving up-right past right barrier or up barrier, switch to down-left movement
        {
            moveValue = (int)movementMode.DownLeft;
        }
        if (moveValue == (int)movementMode.DownLeft && (pastLeft || pastDown))//If moving down-left past left barrier or down barrier, switch to up-right movement
        {
            moveValue = (int)movementMode.UpRight;
        }

        if (moveValue == (int)movementMode.DownRight && (pastRight || pastDown))//If moving down-right past right barrier or down barrier, switch to up-left movement
        {
            moveValue = (int)movementMode.UpLeft;
        }


        //Updates object position and rotation according to movement mode
        switch (moveValue)
        {
            //Up
            case (int)movementMode.Up:
                position = this.transform.position;
                position.y += 0.05f;
                this.transform.position = position;
                this.transform.eulerAngles = new Vector3(-90.0f, 0.0f, 0.0f);
                break;
            //Down
            case (int)movementMode.Down:
                position = this.transform.position;
                position.y -= 0.05f;
                this.transform.position = position;
                this.transform.eulerAngles = new Vector3(-270.0f, -90.0f, 90.0f);
                break;
            //Left
            case (int)movementMode.Left:
                position = this.transform.position;
                position.x -= 0.05f;
                this.transform.position = position;
                this.transform.eulerAngles = new Vector3(-180.0f, 90.0f, -90.0f);
                break;
            //Right
            case (int)movementMode.Right:
                position = this.transform.position;
                position.x += 0.05f;
                this.transform.position = position;
                this.transform.eulerAngles = new Vector3(-180.0f, -90.0f, 90.0f);
                break;
            //Up Right
            case (int)movementMode.UpRight:
                position = this.transform.position;
                position.y += 0.05f;
                this.transform.position = position;
                position = this.transform.position;
                position.x += 0.05f;
                this.transform.position = position;
                this.transform.eulerAngles = new Vector3(-135.0f, -90.0f, 90.0f);
                break;
            //Up Left
            case (int)movementMode.UpLeft:
                position = this.transform.position;
                position.y += 0.05f;
                this.transform.position = position;
                position = this.transform.position;
                position.x -= 0.05f;
                this.transform.position = position;
                this.transform.eulerAngles = new Vector3(-135.0f, 90.0f, -90.0f);
                break;
            //Down Left
            case (int)movementMode.DownLeft:
                position = this.transform.position;
                position.y -= 0.05f;
                this.transform.position = position;
                position = this.transform.position;
                position.x -= 0.05f;
                this.transform.position = position;
                this.transform.eulerAngles = new Vector3(-225.0f, 90.0f, -90.0f);
                break;
            //Down Right
            case (int)movementMode.DownRight:
                position = this.transform.position;
                position.y -= 0.05f;
                this.transform.position = position;
                position = this.transform.position;
                position.x += 0.05f;
                this.transform.position = position;
                this.transform.eulerAngles = new Vector3(-225.0f, -90.0f, 90.0f);
                break;
        }

        //Allows object to switch movement every 3 seconds (unless it hits a barrier)
        if (!cooldown)
        {
            cooldown = true;
            Invoke("ResetCooldown", 3.0f);
        }
    }

    void ResetCooldown()
    {
        cooldown = false;
    }
}
