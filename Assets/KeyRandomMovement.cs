using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyRandomMovement : MonoBehaviour
{
    int moveValue;
    bool cooldown;
    Vector3 position;

    // Start is called before the first frame update
    void Start()
    {
        cooldown = false;
    }

    // Update is called once per frame
    // Code same as RandomMovement, except modified to make the key move faster.
    void FixedUpdate()
    {
        if (!cooldown)
            moveValue = (int)((UnityEngine.Random.value * (0.7999f)) * 10.0f);
        //up 0
        //down 1
        //left 2
        //right 3
        //up right 4
        //up left 5
        //down left 6
        //down right 7

        switch (moveValue)
        {
            //Up
            case 0:
                position = this.transform.position;
                position.y += 0.09f;
                this.transform.position = position;
                break;
            //Down
            case 1:
                position = this.transform.position;
                position.y -= 0.09f;
                this.transform.position = position;

                break;
            //Left
            case 2:
                position = this.transform.position;
                position.x -= 0.09f;
                this.transform.position = position;
                break;
            //Right
            case 3:
                position = this.transform.position;
                position.x += 0.09f;
                this.transform.position = position;
                break;
            //Up Right
            case 4:
                position = this.transform.position;
                position.y += 0.09f;
                this.transform.position = position;
                position = this.transform.position;
                position.x += 0.09f;
                this.transform.position = position;
                break;
            //Up Left
            case 5:
                position = this.transform.position;
                position.y += 0.09f;
                this.transform.position = position;
                position = this.transform.position;
                position.x -= 0.09f;
                this.transform.position = position;
                break;
            //Down Left
            case 6:
                position = this.transform.position;
                position.y -= 0.09f;
                this.transform.position = position;
                position = this.transform.position;
                position.x -= 0.09f;
                this.transform.position = position;
                break;
            //Down Right
            case 7:
                position = this.transform.position;
                position.y -= 0.09f;
                this.transform.position = position;
                position = this.transform.position;
                position.x += 0.09f;
                this.transform.position = position;
                break;
        }


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
