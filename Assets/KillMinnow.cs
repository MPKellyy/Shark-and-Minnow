/**
 * Script Name: KillMinnow
 * Team: Mike, Bryant, Caleb
 * Description: Enables player ability to eat NPC fish. Also allows NPC fish to consume player if they are larger.
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KillMinnow : MonoBehaviour
{
    public GameObject eatSoundHolder;//Incoming sound effect
    public GameObject deathSoundHolder;//Incoming sound effect
    private AudioSource eatSoundSource;//Stores eating sound effect
    private AudioSource deathSoundSource;//Stores death sound effect

    // Start is called before the first frame update
    void Start()
    {
        eatSoundSource = eatSoundHolder.GetComponent<AudioSource>();
        deathSoundSource = deathSoundHolder.GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // This ensures only the Player Fish can eat and get eaten
        if (other.transform.gameObject.name == "Player Fish")
        {
            // Calculating player and NPC fish (or shark) size
            float otherVolume = other.transform.gameObject.transform.localScale.x * other.transform.gameObject.transform.localScale.y * other.transform.gameObject.transform.localScale.z;
            float thisVolume = this.transform.localScale.x * this.transform.localScale.y * this.transform.localScale.z;


            // If NPC fish (or shark) is large than player, eat player
            if (thisVolume >= otherVolume)
            {
                // Play death effect, and show the game over screen.
                GameObject.Find("Game Over Screen").GetComponent<Renderer>().material.color = Color.black;
                Destroy(other.transform.gameObject);
                deathSoundSource.Play();
                Invoke("EndGame", 3.0f);
            }
            else
            {
                // Player eats the NPC fish (or shark).
                Vector3 otherScale = other.transform.gameObject.transform.localScale;
                otherScale.x += 0.05f;
                otherScale.y += 0.05f;
                otherScale.z += 0.05f;
                other.gameObject.transform.localScale = otherScale;
                eatSoundSource.Play();

                Invoke("Die", 0.1f);
            }
        }
    }

    // Kills the fish after it has been eaten.
    // Also opens the gate, if the fish eaten happens to be the shark.
    void Die()
    {
        if(this.transform.gameObject.name == "Shark")
        {
            Invoke("OpenGate", 0.0f);
        }

        Destroy(this.gameObject);
    }

    // Handles gate opening operations.
    void OpenGate()
    {
        Vector3 gate_position;
        string tracker_text;

        // Notifies player that the gate is unlocked.
        tracker_text = "GATE UNLOCKED";
        GameObject.Find("Key Tracker").GetComponent<TextMesh>().text = tracker_text;

        // Lowers the gate.
        gate_position = GameObject.Find("Gate").transform.position;
        gate_position.z = 100.0f;
        GameObject.Find("Gate").transform.position = gate_position;
    }

    // Ends the game.
    void EndGame()
    {
        Application.Quit();
    }
}
