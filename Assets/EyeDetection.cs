using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeDetection : MonoBehaviour {
    public int health1 = 100;
    public int cost1 = 100;


    public int temphealth;
    private void Update()
    {
        Debug.Log(health1);
        if (health1 <= 0)
        {
            Debug.Log("ima dead Cyclops");
            Destroy(this.gameObject); //this can be changed to a victory screen

//            GameObject particleEffect = Resources.Load<GameObject>("Particles/ClubRockParticles");
  //          Instantiate(particleEffect, this.transform.position, Quaternion.identity);
            GameObject End = Resources.Load<GameObject>("EndGame");
            Instantiate(End, this.transform.position, Quaternion.identity);
        }
    }

    public void OnTriggerEnter(Collider other)
    {

        if (other.tag == "eye")
        {
            Debug.Log("hIT");
            
            health1 = health1 - cost1;
            Debug.Log(health1);
            
        }
    }

}
