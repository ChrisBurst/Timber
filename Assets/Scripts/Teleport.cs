using UnityEngine;
using System.Collections;

public class Teleport : MonoBehaviour {
	
	public GameObject Destination;
	AudioSource Noisemaker;

	void Start() {
		Noisemaker = GetComponent<AudioSource> ();
	}


	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			other.transform.position = Destination.transform.position;
			Noisemaker.Play ();
		}
	}
}
