using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeDetection : MonoBehaviour {

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log(collision.name);
        if (collision.name.Equals("EyeSphere")) {
            Debug.Log("Work");

        }   
    }

}
