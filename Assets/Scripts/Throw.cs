using UnityEngine;
using System.Collections;

public class Throw : MonoBehaviour {

	void Awake(){
		rigidbody.AddForce (0f, 250f, 0f);
	}
}
