using UnityEngine;
using System.Collections;

public class ProtoHitscan : MonoBehaviour {

	RaycastHit hit;
	public float distance;
	public GameObject target;
	float YInput;
	float XInput;
	float X;
	float Y;
	public float XSpeed;
	public float YSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		YInput = Input.GetAxis ("Mouse Y");
		XInput = Input.GetAxis("Mouse X");
		transform.Rotate(-YInput, XInput, 0);
		Debug.Log ("Mouse: " + XInput + ", " + YInput);
		target.transform.position = new Vector3 (target.transform.position.x + (XInput*XSpeed), target.transform.position.y + (YInput*YSpeed), 0);
		if (Physics.Raycast(transform.position, transform.forward, out hit))
			distance = hit.distance;
		/*if (distance >500f||distance==0)
			distance = 1;*/
		target.transform.localScale = new Vector3 (1f / (distance/2), 1f / (distance/2), 1f / (distance/2));
	}
}
