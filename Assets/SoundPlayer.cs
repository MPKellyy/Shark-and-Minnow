/**
 * Script Name: SoundPlayer
 * Team: Mike, Bryant, Caleb
 * Description: Script that allows player to consume fish pellets
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    private AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //This ensures only the Player Fish can eat and get eaten
        if (other.transform.gameObject.tag == "Other Fish")
        {
            float otherVolume = other.transform.gameObject.transform.localScale.x * other.transform.gameObject.transform.localScale.y * other.transform.gameObject.transform.localScale.z;
            float thisVolume = this.transform.localScale.x * this.transform.localScale.y * this.transform.localScale.z;


            //If fish has entered player, deleted player
            if (thisVolume >= otherVolume)
            {
                source.Play();
            }
            else
            {

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
