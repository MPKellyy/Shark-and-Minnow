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
        //This ensures only the Player Fish can eat and get eaten
        if (other.transform.gameObject.name == "Player Fish")
        {
            //Calculating player and NPC fish (or shark) size
            float otherVolume = other.transform.gameObject.transform.localScale.x * other.transform.gameObject.transform.localScale.y * other.transform.gameObject.transform.localScale.z;
            float thisVolume = this.transform.localScale.x * this.transform.localScale.y * this.transform.localScale.z;


            //If NOPC fish (or shark) is large than player, eat player
            if (thisVolume >= otherVolume)
            {
                //Play death effect
                Destroy(other.transform.gameObject);
                deathSoundSource.Play();
            }
            else
            {
                //Eat player
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

    void Die()
    {
        Destroy(this.gameObject);
    }

}
