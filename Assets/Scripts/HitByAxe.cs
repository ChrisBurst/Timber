using UnityEngine;
using System.Collections;

public class HitByAxe : MonoBehaviour {

	Vector3 dir;
	GameObject Player;
	GameObject Axe;

	// Use this for initialization
	void Start () {
		Player = GameObject.FindGameObjectWithTag("Player");
		Axe = GameObject.FindGameObjectWithTag("Weapon");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnColliderEnter(Collider other){
		if (other == Axe) {
			print ("Hit by Weapon");
			dir = transform.position - Player.transform.position;
			dir = dir.normalized;
			rigidbody.AddForce (dir * 300);
		}
	}
}