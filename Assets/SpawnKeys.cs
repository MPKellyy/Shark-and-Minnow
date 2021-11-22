using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnKeys : MonoBehaviour
{
    [Header("Inspector-Set Values: ")]
    public GameObject key;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnKey", 0.0f);
    }

    // Update is called once per frame.
    void Update()
    {

    }

    // Spawns a key somewhere on the map.
    void SpawnKey()
    {
        GameObject localkey;
        Vector3 spawnposition;
        float x;
        float y;

        // Spawn three keys.
        for (int i = 0; i < 5; i++)
        {
            localkey = Instantiate<GameObject>(key);
            x = Random.value;       // The key's position on the x-axis.
            y = Random.value;       // The key's position on the y-axis.

            // Adjust the float values accordingly.
            x = (x * (30 + 45)) - 45;
            y = (y * (55 + 20)) - 20;

            spawnposition = new Vector3(x, y, 0.0f);
            localkey.transform.position = spawnposition;
        }
    }
}
