using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BuildZone : MonoBehaviour {

	bool playerInZone=false;
	bool canBuild=false;
	bool activated=false;
	public GameObject BrokenThing;
	public GameObject FixedThing;
	public float logsRequired;
	public AudioSource goodSound;
	public AudioSource badSound;
	public GameObject ButtonPrompt;
	public GameObject BuildON;
	public GameObject BuildOFF;
	GameObject Backpack;
	float logsHave;
	Inventory Inventory;

	// Use this for initialization
	void Start () {
		Backpack = GameObject.FindGameObjectWithTag ("Backpack");
		Inventory = Backpack.GetComponent<Inventory>();
		FixedThing.SetActive(false);
		BrokenThing.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
		if (playerInZone) {
			//Move prompt onscreen
			if(!activated)
				ButtonPrompt.transform.position = Vector3.MoveTowards (ButtonPrompt.transform.position, BuildON.transform.position, 300 * Time.deltaTime);
			//Tell Inventory to show objects
			Backpack.SendMessage ("ShowItem", "Log");
			logsHave = Inventory.yellow;
			if(logsHave >= logsRequired){
				//pull up HUD
				canBuild=true;
				if(Input.GetButtonDown("Fire3")){
					activated=true;
					goodSound.Play();
				}
			}else{
				//pull up "no" HUD
				canBuild=false;
				if(Input.GetButtonDown("Fire3")){
					badSound.Play ();
				}
			}
			if(Input.GetButtonDown("Fire3")&&canBuild){
				activated=true;
			}
		}else
			ButtonPrompt.transform.position = Vector3.MoveTowards (ButtonPrompt.transform.position, BuildOFF.transform.position, 300 * Time.deltaTime);
		if (activated) {
			BrokenThing.SetActive(false);
			FixedThing.SetActive(true);
		}
	
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player")
			playerInZone = true;
	}

	void OnTriggerExit(Collider other){
		if (other.tag == "Player")
			playerInZone = false;
	}

}
