using UnityEngine;
using System.Collections;

public class AttackProto : MonoBehaviour {

	public float ignoreTime=2;
	public float speed=10;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		ignoreTime += Time.deltaTime;
		if (Input.GetButton ("Fire1")&&ignoreTime>1) {
			ignoreTime=0;
		}
		if(ignoreTime<.5f)
			transform.Rotate (Vector3.right * speed * Time.deltaTime);
		if(ignoreTime>=.5f && ignoreTime<1f)
			transform.Rotate (Vector3.left * speed * Time.deltaTime);
	}
}
