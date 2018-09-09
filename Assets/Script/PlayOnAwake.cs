using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOnAwake : MonoBehaviour {

	float timer = 0f;
	ParticleSystem[] systems;

	void Start () {
		for (int i = 0; i < systems.Length; i++) {
			systems [i].Play();
		}
	}
	
	void Update () {
		timer += Time.deltaTime;
	}
}
