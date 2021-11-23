using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    GameObject player;//Saves instance of player object
    Vector3 playerScale;//Saves scale of player object
    float playerVolume;//Saves the size/volume of the player in the world space
    Vector3 thisScale;//Saves the scale of the player in the world space
    float thisVolume;//Saves the volume of this object
    bool green;//Flag for setting this object green

    // Start is called before the first frame update
    void Start()
    {
        green = false;
    }

    // Update is called once per frame
    void Update()
    {
        //If this fish is not green, look for player
        if(!green)
            player = GameObject.Find("Player Fish");

        //If player is not eaten and fish is not green
        if(player != null && !green)
        {
            //Caclulating volume of NPC fish (or shark) and player fish
            playerScale = player.transform.gameObject.transform.localScale;
            playerVolume = playerScale.x * playerScale.y * playerScale.z;
            thisScale = this.transform.localScale;
            thisVolume = thisScale.x * thisScale.y * thisScale.z;

            //If player fish is larger thaan this object, turn this object green
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
