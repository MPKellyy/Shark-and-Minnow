using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLilyPads : MonoBehaviour
{
    [Header("Inspector-Set Values: ")]
    public GameObject lilypad;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnLilyPad", 0.0f);
    }

    // Update is called once per frame.
    void Update()
    {
        
    }

    // Spawns a lily pad somewhere on the map.
    void SpawnLilyPad()
    {
        GameObject locallilypad;
        Vector3 spawnposition;
        Vector3 spawnscale;
        float x;
        float y;
        float scale;

        // Spawns as many lily pads as necessary.
        for (int i = 0; i < 15; i++)
        {
            locallilypad = Instantiate<GameObject>(lilypad);
            x = Random.value;       // The lily pad's position on the x-axis.
            y = Random.value;       // The lily pad's position on the y-axis.
            scale = Random.value;   // Used to affect the lily pad's scale.

            // Adjust the float values accordingly.
            x = (x * (30 + 45)) - 45;
            y = (y * (55 + 20)) - 20;
            scale = (scale * (9 - 3)) + 3;

            spawnposition = new Vector3(x, y, -5.0f);
            locallilypad.transform.position = spawnposition;

            spawnscale = new Vector3(scale, 0.05f, scale);
            locallilypad.transform.localScale = spawnscale;
        }
    }
}
