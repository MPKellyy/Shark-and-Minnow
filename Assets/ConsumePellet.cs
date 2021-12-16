/**
 * Script Name: ConsumePellet
 * Team: Mike, Bryant, Caleb
 * Description: Script that allows player to consume fish pellets
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumePellet : MonoBehaviour
{
    private AudioSource soundSource;//Saves incoming sound effect

    // Start is called before the first frame update
    void Start()
    {
        soundSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //This ensures only the Player Fish can eat pellet
        if (other.transform.gameObject.name == "Player Fish")
        {
            //Eat pellet
            Vector3 otherScale = other.transform.gameObject.transform.localScale;
            soundSource.Play();
            otherScale.x += 0.025f;
            otherScale.y += 0.025f;
            otherScale.z += 0.025f;
            other.gameObject.transform.localScale = otherScale;

            Invoke("Eaten", 0.1f);
        }
    }

    void Eaten()
    {
        Destroy(this.gameObject);
    }
}
