using UnityEngine;
using System.Collections;

public class Tree : MonoBehaviour {

	public float HP=4;
	bool isFalling=false;
	float fallTime=0;
	public float rotateSpeed=5;
	Rigidbody ThisTree;
	public GameObject ItemDropper;

	// Use this for initialization
	void Start () {
		ThisTree = GetComponent<Rigidbody> ();
		ThisTree.isKinematic = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (isFalling) {
			fallTime += Time.deltaTime;
			if (fallTime > 2) {
				ThisTree.isKinematic = false;
			} else {
				transform.Rotate (Vector3.left * rotateSpeed * Time.deltaTime);
			}
			if(fallTime>6){
				ItemDropper.SendMessage("drop","Tree");
				Destroy(this.gameObject);
			}
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Weapon") {
			//print ("Hit by Weapon");
			HP--;
			if(HP<=0)
				isFalling=true;
		}
	}
}
