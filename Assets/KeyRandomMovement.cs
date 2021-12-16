/**
 * Script Name: KeyRandomMovement
 * Team: Mike, Bryant, Caleb
 * Description: Like the RandomMovement script for NPC fish, but slightly altered for keys.
 * Ideally, the keys move faster than the NPC fish so that they are harder to catch.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyRandomMovement : MonoBehaviour
{
    int moveValue;//Determines which direction object will move
    bool cooldown;//Allows object movement to change over specfifed amount of time
    Vector3 position;//Saves object position
    bool pastLeft;//Left barrier check
    bool pastRight;//Right barrier check
    bool pastUp;//Up barrier check
    bool pastDown;//Down barrier check
    //Values for movement direction
    enum MovementMode
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
    // Code same as RandomMovement, except modified to make the key move faster.
    void FixedUpdate()
    {
        //Generating a movement mode
        if (!cooldown)
            moveValue = (int)((UnityEngine.Random.value * (0.7999f)) * 10.0f);


        //Checking if object posiition is past the defined barriers in-game
        position = this.transform.position;
        pastLeft = position.x <= -50.3f;
        pastRight = position.x >= 40.1f;
        pastUp = position.y >= 64.5f;
        pastDown = position.y <= -27.8f;

        if (moveValue == (int)MovementMode.Left && pastLeft)//If moving left past left barrier, switch to right movement
        {
            moveValue = (int)MovementMode.Right;
        }
        if (moveValue == (int)MovementMode.Right && pastRight)//If moving right past right barrier, switch to left movement
        {
            moveValue = (int)MovementMode.Left;
        }
        if (moveValue == (int)MovementMode.Up && pastUp)//If moving up past up barrier, switch to down movement
        {
            moveValue = (int)MovementMode.Down;
        }
        if (moveValue == (int)MovementMode.Down && pastDown)//If moving down past down barrier, switch to up movement
        {
            moveValue = (int)MovementMode.Up;
        }
        if (moveValue == (int)MovementMode.UpLeft && (pastLeft || pastUp))//If moving up-left past left barrier or up barrier, switch to down-right movement
        {
            moveValue = (int)MovementMode.DownRight;
        }
        if (moveValue == (int)MovementMode.UpRight && (pastRight || pastUp))//If moving up-right past right barrier or up barrier, switch to down-left movement
        {
            moveValue = (int)MovementMode.DownLeft;
        }
        if (moveValue == (int)MovementMode.DownLeft && (pastLeft || pastDown))//If moving down-left past left barrier or down barrier, switch to up-right movement
        {
            moveValue = (int)MovementMode.UpRight;
        }

        if (moveValue == (int)MovementMode.DownRight && (pastRight || pastDown))//If moving down-right past right barrier or down barrier, switch to up-left movement
        {
            moveValue = (int)MovementMode.UpLeft;
        }


        //Updates object position and rotation according to movement mode
        switch (moveValue)
        {
            //Up
            case (int)MovementMode.Up:
                position = this.transform.position;
                position.y += 0.09f;
                this.transform.position = position;
                break;
            //Down
            case (int)MovementMode.Down:
                position = this.transform.position;
                position.y -= 0.09f;
                this.transform.position = position;

                break;
            //Left
            case (int)MovementMode.Left:
                position = this.transform.position;
                position.x -= 0.09f;
                this.transform.position = position;
                break;
            //Right
            case (int)MovementMode.Right:
                position = this.transform.position;
                position.x += 0.09f;
                this.transform.position = position;
                break;
            //Up Right
            case (int)MovementMode.UpRight:
                position = this.transform.position;
                position.y += 0.09f;
                this.transform.position = position;
                position = this.transform.position;
                position.x += 0.09f;
                this.transform.position = position;
                break;
            //Up Left
            case (int)MovementMode.UpLeft:
                position = this.transform.position;
                position.y += 0.09f;
                this.transform.position = position;
                position = this.transform.position;
                position.x -= 0.09f;
                this.transform.position = position;
                break;
            //Down Left
            case (int)MovementMode.DownLeft:
                position = this.transform.position;
                position.y -= 0.09f;
                this.transform.position = position;
                position = this.transform.position;
                position.x -= 0.09f;
                this.transform.position = position;
                break;
            //Down Right
            case (int)MovementMode.DownRight:
                position = this.transform.position;
                position.y -= 0.09f;
                this.transform.position = position;
                position = this.transform.position;
                position.x += 0.09f;
                this.transform.position = position;
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
