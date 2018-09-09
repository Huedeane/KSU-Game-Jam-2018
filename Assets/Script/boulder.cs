using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boulder : MonoBehaviour {
//	public int rockNum = 2;
	public int sidePower= 10;
	public int upPower= 10;
	public Transform[] boulderPoints;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider c)
	{
        Debug.Log(c.gameObject);
//		Debug.Log ("Eggs");
		if (c.gameObject.tag == "test") {
//			Debug.Log ("ima dead boulder");
			Destroy (this.gameObject); 

			for (int i = 0;i < boulderPoints.Length; i++){
				float x = Random.Range (-1f, 1f);
				float z = Random.Range (-1f, 1f);
				upPower = Random.Range (100, 250);
//				Debug.Log (x + " " + y);
				GameObject boulderSpawn = Resources.Load<GameObject> ("ColectableRock");
				// don't forget to create an empty object and name it boulderPoint
				GameObject rock = (GameObject)Instantiate(boulderSpawn, boulderPoints[i].position, Quaternion.identity);
				Vector3 direction = new Vector3 (x * sidePower, upPower, z * sidePower);
				Debug.Log (direction);
				rock.GetComponent<Rigidbody> ().AddForce (direction);
			}
		}
	}
}
