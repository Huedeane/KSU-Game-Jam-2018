using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour {

	float timer = 0f;
	public float fadeTime = 2f;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
//		Time.timeScale = (fadeTime - timer) / fadeTime;
//		Debug.Log (Time.timeScale);
		if (timer > fadeTime) {
			Debug.Log ("Done");
			Time.timeScale = 1;
			SceneManager.LoadScene (0);
		}
	}
}
