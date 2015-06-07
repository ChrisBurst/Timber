using UnityEngine;
using System.Collections;

public class Squirrel : MonoBehaviour {

	GameObject squirrel;
	Collider target;
	bool inTransit;
	public float speed;

	// Use this for initialization
	void Start () {
		squirrel=GameObject.FindGameObjectWithTag ("Squirrel");
	}
	
	// Update is called once per frame
	void Update () {
		if (inTransit&&target!=null) {
			squirrel.transform.position = Vector3.MoveTowards (squirrel.transform.position, target.transform.position, speed * Time.deltaTime);
			if (squirrel.transform.position == target.transform.position)
				inTransit = false;
		} if(target==null) {
			squirrel.transform.position = Vector3.MoveTowards (squirrel.transform.position, transform.position, speed * Time.deltaTime);
		}

	}

	void OnTriggerStay(Collider other){
		if (other.tag == "Collectable") {
			//if (!inTransit) {
				target = other;
				inTransit = true;
			//}
		}
	}

}
