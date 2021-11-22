using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillMinnow : MonoBehaviour
{
    public GameObject eatSoundHolder;
    public GameObject deathSoundHolder;
    private AudioSource eatSoundSource;
    private AudioSource deathSoundSource;

    bool eaten = false;
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
        if(other.transform.gameObject.name == "Player Fish")
        {
            float otherVolume = other.transform.gameObject.transform.localScale.x * other.transform.gameObject.transform.localScale.y * other.transform.gameObject.transform.localScale.z;
            float thisVolume = this.transform.localScale.x * this.transform.localScale.y * this.transform.localScale.z;


            //If fish has entered player, deleted player
            if (thisVolume >= otherVolume)
            {
                Destroy(other.transform.gameObject);
                deathSoundSource.Play();
            }
            else
            {
                if (eaten == false)
                {
                    Vector3 otherScale = other.transform.gameObject.transform.localScale;
                    otherScale.x += 0.2f;
                    otherScale.y += 0.2f;
                    otherScale.z += 0.2f;
                    other.gameObject.transform.localScale = otherScale;
                    eatSoundSource.Play();
                    eaten = true;
                }
                Invoke("Die", 0.1f);
            }
        }
    }

    void Die()
    {
        Destroy(this.gameObject);
    }

}
