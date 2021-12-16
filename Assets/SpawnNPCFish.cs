/**
 * Script Name: SpawnNPCFish
 * Team: Mike, Bryant, Caleb
 * Description: Randomly spawns NPC fish throughtout the map.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNPCFish : MonoBehaviour
{
    [Header("Inspector-Set Values: ")]
    public GameObject fish;

    // Start is called before the first frame update
    void Start()
    {
        // Initially spawn 10 NPC fish.
        for (int i = 0; i < 10; i++)
        {
            Invoke("SpawnFish", 0.0f);
        }

        // Spawn another NPC fish every 30 seconds.
        Invoke("SpawnFishContinuous", 30.0f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Spawns a fish somewhere on the map.
    void SpawnFish()
    {
        GameObject localfish;
        Vector3 spawnposition;
        float x;
        float y;

        localfish = Instantiate<GameObject>(fish);
        x = Random.value;       // The fish's position on the x-axis.
        y = Random.value;       // The fish's position on the y-axis.

        // Adjust the float values accordingly.
        x = (x * (30 + 45)) - 45;
        y = (y * (55 + 20)) - 20;

        // Ensures that the NPC fish does not spawn on player's initial position.
        if(!(x < 3 && x > -3) && !(y < 7 && y > 1))
        {
            spawnposition = new Vector3(x, y, 0.0f);
            localfish.transform.position = spawnposition;
        }
        else
        {
            Invoke("SpawnFish", 0.0f);
        }
        
    }

    // Same as SpawnFish(), but it invokes itself at the end.
    void SpawnFishContinuous()
    {
        GameObject localfish;
        Vector3 spawnposition;
        Vector3 spawnscale;
        float x;
        float y;
        float scale;

        localfish = Instantiate<GameObject>(fish);
        x = Random.value;       // The fish's position on the x-axis.
        y = Random.value;       // The fish's position on the y-axis.
        scale = Random.value;   // Used to affect the fish's scale.

        // Adjust the float values accordingly.
        x = (x * (30 + 45)) - 45;
        y = (y * (55 + 20)) - 20;
        scale = (scale * (2.0f - 0.5f)) + 0.5f;

        spawnposition = new Vector3(x, y, 0.0f);
        localfish.transform.position = spawnposition;

        spawnscale = new Vector3(scale, scale, scale);
        localfish.transform.localScale = spawnscale;

        Invoke("SpawnFishContinuous", 30.0f);
    }
}
