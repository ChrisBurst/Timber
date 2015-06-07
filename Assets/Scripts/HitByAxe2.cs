using UnityEngine;
using System.Collections;

public class HitByAxe2 : MonoBehaviour {

	GameObject Axe;

	// Use this for initialization
	void Start () {
		Axe = GameObject.FindGameObjectWithTag("Weapon");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		//if (other == Axe.collider) {
			print ("Hit by Weapon");
		//}
	}
}
