using UnityEngine;
using System.Collections;

public class SquirrelTracker : MonoBehaviour {


	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		Debug.Log ("Encountered " + other);
	}
}
