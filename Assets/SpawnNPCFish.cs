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
        for (int i = 0; i < 10; i++)
        {
            Invoke("SpawnFish", 0.0f);
        }

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

        spawnposition = new Vector3(x, y, 0.0f);
        localfish.transform.position = spawnposition;
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
