using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PursuePlayer : MonoBehaviour
{
    Queue playerLocations;
    bool cooldown;
    float roundCounter;
    float timetracker;
    bool peakSpeed;
    Vector3 playerPos;
    Vector3 previousPos;
    bool playerAlive;
    (Vector3, Vector3) playerSave;
    int doublePace;
    GameObject player;
    int doublePaceTracker;

    // Start is called before the first frame update
    void Start()
    {
        playerLocations = new Queue();
        cooldown = false;
        peakSpeed = false;
        roundCounter = 1;
        timetracker = 0.0f;
        playerAlive = true;
        doublePaceTracker = -1;

         player = GameObject.Find("Player Fish");

        for (float y = this.gameObject.transform.position.y; y < player.transform.position.y; y += 0.1f)
        {
            playerSave = (new Vector3(0.0f, y, 0.0f), new Vector3(-90.0f, 0.0f, 0.0f));
            playerLocations.Enqueue(playerSave);
        }


        print("Level 1");

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        player = GameObject.Find("Player Fish");

        if (player == null)
            playerAlive = false;
        else
        {
            previousPos = playerPos;
            playerPos = player.transform.position;
            playerSave = (playerPos, player.transform.eulerAngles);
        }




        if(previousPos!=playerPos && playerAlive)
        {
            playerLocations.Enqueue(playerSave);
        }


        if(peakSpeed && playerLocations.Count != 0 && playerAlive)
        {
            if(doublePaceTracker != 0)
            {
                timetracker += 0.01f;

                if (timetracker >= 10.0f)
                {
                    doublePaceTracker = 0;
                    print("Level 3");
                }
            }

            //Switch?

            playerSave = ((Vector3, Vector3)) playerLocations.Dequeue();


            //This doubles shark speed randomly after a certain amount of time
            doublePace = (int)(UnityEngine.Random.value + 0.5f);//0 = double, 1 = single pace


            if (playerLocations.Count != 0 && doublePace == doublePaceTracker) {
                playerSave = ((Vector3, Vector3))playerLocations.Dequeue();
                print("Double");
            }
            else
            {
                print("Single");
            }

            //Put this transform logic in a switch statement for both cases
            this.transform.position = playerSave.Item1;
            this.transform.eulerAngles = playerSave.Item2;
        }
        else if (playerLocations.Count != 0 && !cooldown && playerAlive) {
            playerSave = ((Vector3, Vector3))playerLocations.Dequeue();
            this.transform.position = playerSave.Item1;
            this.transform.eulerAngles = playerSave.Item2;
            cooldown = true;
            timetracker += 0.01f;


            if(timetracker >= 2.0f)
            {
                timetracker = 0.0f;
                roundCounter--;
                print(playerLocations.Count);
            }

            SpeedCheck();
        }

           

    }

    void ResetCooldown() {
        cooldown = false;
    }

    void SpeedCheck()
    {
        if (roundCounter < 1)
        {
            peakSpeed = true;
            print("Level 2");
        }
        else
        {
            Invoke("ResetCooldown", 0.05f);
        }
    }


}
