using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    GameObject player;
    Vector3 playerScale;
    float playerVolume;
    Vector3 thisScale;
    float thisVolume;
    bool green;

    // Start is called before the first frame update
    void Start()
    {
        green = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!green)
            player = GameObject.Find("Player Fish");

        if(player != null && !green)
        {
            playerScale = player.transform.gameObject.transform.localScale;
            playerVolume = playerScale.x * playerScale.y * playerScale.z;
            thisScale = this.transform.localScale;
            thisVolume = thisScale.x * thisScale.y * thisScale.z;

            if (thisVolume < playerVolume)
            {
                foreach (Transform child in this.transform)
                {
                    child.GetComponent<Renderer>().material.color = Color.green;
                    green = true;
                }
            }
        }


    }
}
