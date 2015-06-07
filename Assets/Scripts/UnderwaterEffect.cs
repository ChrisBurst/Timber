using UnityEngine;
using System.Collections;

public class UnderwaterEffect : MonoBehaviour {

	public GameObject WaterFilter;

	// Use this for initialization
	void Start () {
		WaterFilter.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "MainCamera"){
			WaterFilter.SetActive (true);
		}
	}
	void OnTriggerExit(Collider other){
		if(other.tag == "MainCamera")
			WaterFilter.SetActive (false);
	}
}
