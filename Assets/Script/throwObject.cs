using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throwObject : MonoBehaviour {
	public Vector3 pwr;
	GameObject test;
	public Transform spawnPoint;
	public int power = 200;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Mouse0) && GameObject.Find("FPSController").GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().ObjectInHand == true) {
            GameObject.Find("FPSController").GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().ObjectInHand = false;
            test = Resources.Load<GameObject>("rock");
			GameObject rock = (GameObject)Instantiate(test, spawnPoint.position, Quaternion.identity);
			rock.GetComponent<Rigidbody>().AddRelativeForce(this.transform.forward*power);
		}
	}
}
