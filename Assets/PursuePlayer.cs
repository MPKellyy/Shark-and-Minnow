using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PursuePlayer : MonoBehaviour
{
    Queue playerLocations;
    bool cooldown;
    float time;
    float timetracker;
    bool peakSpeed;
    Vector3 playerPos;
    Vector3 previousPos;
    bool playerAlive;
    bool canMove;
    (Vector3, Vector3) playerSave;

    // Start is called before the first frame update
    void Start()
    {
        playerLocations = new Queue();
        cooldown = false;
        peakSpeed = false;
        time = 0.06f;
        timetracker = 0.0f;
        playerAlive = true;
        canMove = false;
        Invoke("moveDelay", 1.5f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GameObject player = GameObject.Find("Player Fish");

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


        if(peakSpeed && playerLocations.Count != 0 && playerAlive && canMove)
        {
            if(playerLocations.Count % 2 == 0)
            {
                playerLocations.Dequeue();
                playerSave = ((Vector3, Vector3)) playerLocations.Dequeue();
                this.transform.position = playerSave.Item1;
                this.transform.eulerAngles = playerSave.Item2;

            }
            else {
                playerSave = ((Vector3, Vector3))playerLocations.Dequeue();
                this.transform.position = playerSave.Item1;
                this.transform.eulerAngles = playerSave.Item2;
            }
        }
        else if (playerLocations.Count != 0 && !cooldown && playerAlive && canMove) {
            playerSave = ((Vector3, Vector3))playerLocations.Dequeue();
            this.transform.position = playerSave.Item1;
            this.transform.eulerAngles = playerSave.Item2;
            cooldown = true;
            timetracker += time;
            if(timetracker >= 10.0f)
            {
                timetracker = 0.0f;
                time -= 0.005f;
                print("Time now: " + time);
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
        if (time < 0.005f)
        {
            peakSpeed = true;
            print("Peak Speed");
        }
        else
        {
            Invoke("ResetCooldown", time);
        }
    }

    void moveDelay()
    {
        canMove = true;
    }


}
