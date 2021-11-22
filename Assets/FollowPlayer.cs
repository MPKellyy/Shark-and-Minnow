using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("Player Fish");

        if(player != null)
        {
            Vector3 playerPos = player.transform.position;
            playerPos.z = -10.0f;

            this.transform.position = playerPos;
        }


    }


}
