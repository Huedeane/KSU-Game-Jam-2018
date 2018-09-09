using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cyclops : MonoBehaviour {
	public int health = 100;
	public int cost = 50;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider c)
	{
		Debug.Log ("Eggs");
		health = health - cost;
		if (health <= 0) {
			Debug.Log ("ima dead Cyclops");
			Destroy (this.gameObject); //this can be changed to a victory screen
		}
	}
}
