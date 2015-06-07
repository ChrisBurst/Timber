using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

	public float Xspin=150;
	public float Yspin=0;
	public float Zspin=0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (Xspin*Time.deltaTime, Yspin*Time.deltaTime, Zspin*Time.deltaTime);
	}
}
