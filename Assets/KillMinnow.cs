using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillMinnow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //If cabbage has entered player, deleted player
        if (other.transform.gameObject.name == "Player Fish")
        {
            Destroy(other.transform.gameObject);
            Application.Quit();
        }
    }

}
