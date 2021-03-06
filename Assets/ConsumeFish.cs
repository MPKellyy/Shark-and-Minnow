/**
 * Script Name: ConsumeFish
 * Team: Mike, Bryant, Caleb
 * Description: Script used for player to eat NPC fish. Also allows NPC fish to consume player if they are larger.
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumeFish : MonoBehaviour
{
    public GameObject eatSoundHolder;//Incoming sound effect
    private AudioSource eatSoundSource;//Variable that holds the incoming sound

    // Start is called before the first frame update
    void Start()
    {
        eatSoundSource = eatSoundHolder.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        //This ensures only the Player Fish can eat and get eaten
        if (other.transform.gameObject.name == "Player Fish")
        {
            //Calculating volume of player and NPC fish (or shark)
            float otherVolume = other.transform.gameObject.transform.localScale.x * other.transform.gameObject.transform.localScale.y * other.transform.gameObject.transform.localScale.z;
            float thisVolume = this.transform.localScale.x * this.transform.localScale.y * this.transform.localScale.z;

            // NPC fish (or shark) is only eaten if it is smaller than the player fish.
            if (otherVolume > thisVolume)
           {
                Vector3 otherScale = other.transform.gameObject.transform.localScale;
                otherScale.x += 0.05f;
                otherScale.y += 0.05f;
                otherScale.z += 0.05f;
                other.gameObject.transform.localScale = otherScale;

                //Play sound effect
                eatSoundSource.Play();
                Destroy(this.gameObject);
           }
        }
    }
}
