using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour
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
    void FixedUpdate()
    {
        if(!cooldown)
            moveValue = (int) ((UnityEngine.Random.value * (0.7999f))*10.0f);
        //up 0
        //down 1
        //left 2
        //right 3
        //up right 4
        //up left 5

        //down left 6
        //down right 7


        switch(moveValue)
        {
            //Up
            case 0:
                position = this.transform.position;
                position.y += 0.05f;
                this.transform.position = position;
                this.transform.eulerAngles = new Vector3(-90.0f, 0.0f, 0.0f);
                break;
            //Down
            case 1:
                position = this.transform.position;
                position.y -= 0.05f;
                this.transform.position = position;
                this.transform.eulerAngles = new Vector3(-270.0f, -90.0f, 90.0f);
                break;
            //Left
            case 2:
                position = this.transform.position;
                position.x -= 0.05f;
                this.transform.position = position;
                this.transform.eulerAngles = new Vector3(-180.0f, 90.0f, -90.0f);
                break;
            //Right
            case 3:
                position = this.transform.position;
                position.x += 0.05f;
                this.transform.position = position;
                this.transform.eulerAngles = new Vector3(-180.0f, -90.0f, 90.0f);
                break;
            //Up Right
            case 4:
                position = this.transform.position;
                position.y += 0.05f;
                this.transform.position = position;
                position = this.transform.position;
                position.x += 0.05f;
                this.transform.position = position;
                this.transform.eulerAngles = new Vector3(-135.0f, -90.0f, 90.0f);
                break;
            //Up Left
            case 5:
                position = this.transform.position;
                position.y += 0.05f;
                this.transform.position = position;
                position = this.transform.position;
                position.x -= 0.05f;
                this.transform.position = position;
                this.transform.eulerAngles = new Vector3(-135.0f, 90.0f, -90.0f);
                break;
            //Down Left
            case 6:
                position = this.transform.position;
                position.y -= 0.05f;
                this.transform.position = position;
                position = this.transform.position;
                position.x -= 0.05f;
                this.transform.position = position;
                this.transform.eulerAngles = new Vector3(-225.0f, 90.0f, -90.0f);
                break;
            //Down Right
            case 7:
                position = this.transform.position;
                position.y -= 0.05f;
                this.transform.position = position;
                position = this.transform.position;
                position.x += 0.05f;
                this.transform.position = position;
                this.transform.eulerAngles = new Vector3(-225.0f, -90.0f, 90.0f);
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
