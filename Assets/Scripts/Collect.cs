using UnityEngine;
using System.Collections;

public class Collect : MonoBehaviour {

	//public ParticleEmitter sparkle;
	public float sparkletime=1;
	public GameObject Backpack;
	public GameObject Player;
	bool collected;
	public bool hasParticle=true;
	Rigidbody thisBody;
	Vector3 dir;
	public float speed=6;
	bool grabbed=false;

	void Start(){
		collected = false;
		thisBody = GetComponent<Rigidbody> ();
		thisBody.isKinematic = true;
		//sparkle.enabled = false;
		Backpack = GameObject.FindGameObjectWithTag ("Backpack");
		if (Backpack == null) {
			Debug.Log ("Can't find Backpack object");
		}
		Player = GameObject.FindGameObjectWithTag ("Player");
	}

	void Update(){
		if (grabbed)
			transform.position = Vector3.MoveTowards (transform.position, Player.transform.position, speed * Time.deltaTime);
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			if (!collected) {
				Backpack.SendMessage ("AddItem", gameObject.name);
				this.renderer.enabled = false;
				/*if(hasParticle){
					sparkle.enabled = true;
					sparkle.transform.parent = null;
					Destroy (sparkle, sparkletime);
				}*/
				Destroy (gameObject, sparkletime);
				collected = true;
			}
		}if (other.tag == "Squirrel") {
			transform.parent=null;
			thisBody.isKinematic = false;
			//dir = Player.transform.position - transform.position;
			//dir = dir.normalized;
			//thisBody.AddForce (dir * 300);
			grabbed=true;
		}
	}
}
