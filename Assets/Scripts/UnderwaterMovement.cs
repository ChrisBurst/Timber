using UnityEngine;
using System.Collections;

public class UnderwaterMovement : MonoBehaviour {

	public bool inWater=false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (inWater) {
			rigidbody.AddForce (Vector3.up * 100);
			if (Input.GetButtonDown ("Jump")) {
				rigidbody.AddForce (Vector3.up * 1000);
			}
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Water"){
			inWater=true;
		}
	}
	void OnTriggerExit(Collider other){
		if (other.tag == "Water")
			inWater = false;
	}
}
