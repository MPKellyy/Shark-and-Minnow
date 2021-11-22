using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumePellet : MonoBehaviour
{
    public GameObject eatSoundHolder;
    private AudioSource eatSoundSource;
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
            Vector3 otherScale = other.transform.gameObject.transform.localScale;
            otherScale.x += 0.05f;
            otherScale.y += 0.05f;
            otherScale.z += 0.05f;
            other.gameObject.transform.localScale = otherScale;
            eatSoundSource.Play();
            Destroy(this.gameObject);
        }
    }
}
