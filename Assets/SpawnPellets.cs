/**
 * Script Name: SpawnPellets
 * Team: Mike, Bryant, Caleb
 * Description: Randomly spawns pellets throughtout the map.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPellets : MonoBehaviour
{
    [Header("Inspector-Set Values: ")]
    public GameObject pellet;

    // Start is called before the first frame update
    void Start()
    {
        // Initially spawns 50 pellets.
        for (int i = 0; i < 50; i++)
        {
            Invoke("SpawnPellet", 0.0f);
        }

        // Spawns more pellets after the initial batch.
        Invoke("SpawnPelletContinuous", 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Spawns a pellet somewhere on the map.
    void SpawnPellet()
    {
        GameObject localpellet;
        Vector3 spawnposition;
        float x;
        float y;

        localpellet = Instantiate<GameObject>(pellet);
        x = Random.value;       // The pellet's position on the x-axis.
        y = Random.value;       // The pellet's position on the y-axis.

        // Adjust the float values accordingly.
        x = (x * (30 + 45)) - 45;
        y = (y * (55 + 20)) - 20;

        spawnposition = new Vector3(x, y, 0.0f);
        localpellet.transform.position = spawnposition;
    }

    // Same as SpawnPellet(), but it invokes itself at the end.
    void SpawnPelletContinuous()
    {
        GameObject localpellet;
        Vector3 spawnposition;
        float x;
        float y;

        localpellet = Instantiate<GameObject>(pellet);
        x = Random.value;       // The pellet's position on the x-axis.
        y = Random.value;       // The pellet's position on the y-axis.

        // Adjust the float values accordingly.
        x = (x * (30 + 45)) - 45;
        y = (y * (55 + 20)) - 20;

        spawnposition = new Vector3(x, y, 0.0f);
        localpellet.transform.position = spawnposition;

        Invoke("SpawnPelletContinuous", 3.0f);
    }
}
