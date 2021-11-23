using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyTrackerFunctionality : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Deletes the key when the player catches it.
    void OnTriggerEnter(Collider other)
    {
        Vector3 gate_position;
        string tracker_text;
        char key_count;
        int key_count_int;

        if (other.transform.gameObject.name == "Player Fish")
        {
            // Get the key count from the key tracker text.
            tracker_text = GameObject.Find("Key Tracker").GetComponent<TextMesh>().text;
            key_count = tracker_text[16];
            key_count_int = int.Parse(key_count.ToString());
            key_count_int++;

            // If all keys have been collected, lower the gate and notify the player.
            if(key_count_int == 5)
            {
                // Notifies player that the gate is unlocked.
                tracker_text = "GATE UNLOCKED";
                GameObject.Find("Key Tracker").GetComponent<TextMesh>().text = tracker_text;

                // Lowers the gate.
                gate_position = GameObject.Find("Gate").transform.position;
                gate_position.z = 100.0f;
                GameObject.Find("Gate").transform.position = gate_position;
            }
            else
            {
                tracker_text = "Keys Collected: " + key_count_int + " / 5";
                GameObject.Find("Key Tracker").GetComponent<TextMesh>().text = tracker_text;
            }

            // Destroys the key (parent is used here as this script is attached to a "hitbox",
            // rather than the entire prefab.
            Destroy(transform.parent.gameObject);
        }
    }
}
