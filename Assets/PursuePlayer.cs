using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PursuePlayer : MonoBehaviour
{
    Queue playerLocations;//Queue used to store player locations
    float timeTracker;//Used to keep track of elapsed time in game
    public float timeUntilSwitch;//Dictates when how much time until shark switches from normal speed to double speed
    Vector3 playerPos;//Stores players position in the current frame
    Vector3 previousPos;//Stores players position in a the previous frame
    bool playerAlive;//Keeps track of if player is still alive in game
    (Vector3, Vector3) playerSave;//Stores player position in Item1, stores player rotation in Item2
    int varyMovement;//Variable used to randomly affect shark movement speed
    GameObject player;//Used to hold instance of a player object
    int MovementMode;//Decides speed of shark movement, -1 is normal speed, 0 is double speed

    // Start is called before the first frame update
    void Start()
    {
        //Creating a queue to store player locations
        playerLocations = new Queue();

        //Setting up variables
        timeTracker = 0.0f;
        playerAlive = true;
        MovementMode = -1;//Shark speed set to normal

        //Finding player in game space
         player = GameObject.Find("Player Fish");

        //Filling queue with coordinates between shark and player on spawn
        for (float y = this.gameObject.transform.position.y; y < player.transform.position.y; y += 0.1f)
        {
            playerSave = (new Vector3(0.0f, y, 0.0f), new Vector3(-90.0f, 0.0f, 0.0f));
            playerLocations.Enqueue(playerSave);
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Checking if player is alive
        player = GameObject.Find("Player Fish");

        if (player == null)//If player not found, player is dead
            playerAlive = false;
        else//Save player's position and rotation in the game space
        {
            previousPos = playerPos;
            playerPos = player.transform.position;
            playerSave = (playerPos, player.transform.eulerAngles);
        }


        //Save the current position only if player is not standing still (keeps shark constantly moving)
        if(previousPos!=playerPos && playerAlive)
        {
            playerLocations.Enqueue(playerSave);
        }


        //While there are still locations to go to and the player is alive
        if(playerLocations.Count != 0 && playerAlive)
        {
            //Checking if shark is not in double speed (in other words, if its currently in normal speed)
            if(MovementMode != 0)
            {
                //Update the time tracker
                timeTracker += 0.01f;

                //Once timeTracker reaches a certain threshold, switch to double speed
                if (timeTracker >= timeUntilSwitch)
                {
                    MovementMode = 0;
                    print("Double");
                }
            }


            //Reading current movement mode
            switch(MovementMode)
            {
                //Case for double speed
                case 0:
                    //Garuntees at least one movement per frame
                    playerSave = ((Vector3, Vector3))playerLocations.Dequeue();


                    //This randomly doubles shark movement per frame. Allows player more time to escape from it, makes movement less robotic
                    varyMovement = (int)(UnityEngine.Random.value + 0.5f);//0 = double movement, 1 = single pace

                    //If queue is not empty and varyMovement wants to double the pace
                    if (playerLocations.Count != 0 && (UnityEngine.Random.value) < 0.10f)
                    {
                        //Load an additional position
                        playerSave = ((Vector3, Vector3))playerLocations.Dequeue();
                    }

                    //Update position
                    this.transform.position = playerSave.Item1;
                    this.transform.eulerAngles = playerSave.Item2;

                    break;

                //Case for normal speed
                case -1:
                    //This randomly slows shark movement once per frame. Allows player more time to escape from it, makes movement less robotic


                    //If queue is not empty and varyMovement wants to move one pace
                    if (playerLocations.Count != 0 && (UnityEngine.Random.value) > 0.05f)
                    {
                        //Load an additional position
                        playerSave = ((Vector3, Vector3))playerLocations.Dequeue();

                        //Only update position if moving a single position (transforming stays in this if statement)
                        this.transform.position = playerSave.Item1;
                        this.transform.eulerAngles = playerSave.Item2;
                    }

                    break;
            }
        }
    }

}
