using UnityEngine;
using System.Collections;

public class SpiderMoveAI : MonoBehaviour {

	public float speed=1;
	public GameObject Home;
	GameObject Player;
	float distance;
	public float maxDistance=20;
	NavMeshAgent navigation;

	// Use this for initialization
	void Start () {
		Player=GameObject.FindGameObjectWithTag ("Player");
		navigation = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
		distance = Vector3.Distance (Player.transform.position, gameObject.transform.position);
		if (distance < maxDistance) {
			//transform.LookAt(Player.transform.position);
			navigation.SetDestination(Player.transform.position);
			transform.position = Vector3.MoveTowards (transform.position, Player.transform.position, speed * Time.deltaTime);
		} else {
			transform.LookAt (Home.transform.position);
			transform.position = Vector3.MoveTowards (transform.position, Home.transform.position, speed * Time.deltaTime);
		}
	}
}
