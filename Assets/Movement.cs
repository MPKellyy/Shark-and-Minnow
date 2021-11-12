using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    bool up;
    bool down;
    bool left;
    bool right;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        up = false;
        down = false;
        left = false;
        right = false;


        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Vector3 position = this.transform.position;
            position.x-= 0.1f;
            this.transform.position = position;
            left = true;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Vector3 position = this.transform.position;
            position.x+= 0.1f;
            this.transform.position = position;
            right = true;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Vector3 position = this.transform.position;
            position.y+= 0.1f;
            this.transform.position = position;
            up = true;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            Vector3 position = this.transform.position;
            position.y-= 0.1f;
            this.transform.position = position;
            down = true;
        }

        SetPosition();
    }

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
