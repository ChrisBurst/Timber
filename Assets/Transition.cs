using UnityEngine;
using System.Collections;

public class Transition : MonoBehaviour {

	float X=1000;
	float Y=1000;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.localScale = new Vector3 (X, Y, 0f);
		X -= 500*Time.deltaTime;
		Y -= 500*Time.deltaTime;
	}
}
