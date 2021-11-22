using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateSwimming : MonoBehaviour
{
    int callCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Tail fin should be altered by 0.1 degrees in 0.01 second increments.
        Invoke("MoveLeft", 0.01f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    // MoveLeft and MoveRight both rotate the tail fin in order to animate swimming.
    void MoveLeft()
    {
        Vector3 left;
        left.x = this.transform.eulerAngles.x + 0.1f;
        left.y = this.transform.eulerAngles.y;
        left.z = this.transform.eulerAngles.z;

        this.transform.eulerAngles = left;

        callCount++;

        if (callCount == 150)
        {
            callCount = 0;
            Invoke("MoveRight", 0.01f);
        }
        else
        {
            Invoke("MoveLeft", 0.01f);
        }
    }

    void MoveRight()
    {
        Vector3 right;
        right.x = this.transform.eulerAngles.x - 0.1f;
        right.y = this.transform.eulerAngles.y;
        right.z = this.transform.eulerAngles.z;

        this.transform.eulerAngles = right;

        callCount++;

        if (callCount == 150)
        {
            callCount = 0;
            Invoke("MoveLeft", 0.01f);
        }
        else
        {
            Invoke("MoveRight", 0.01f);
        }
    }
}
