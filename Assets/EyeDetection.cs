using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeDetection : MonoBehaviour {


    public void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if(other.tag == "eye")
        {
            Debug.Log("EYE HIT!");
        }
    }

}
