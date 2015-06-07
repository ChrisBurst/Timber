using UnityEngine;
using System.Collections;

public class EnemyAIScript : MonoBehaviour {

	public Transform Player;

	public int HP = 1;
	private Vector3 spawnPoint;

	public float playerDistance;
	public float rotationDamping;
	public float moveSpeed;

	public bool wandering = false;
	public float wanderTimer;
	public float waitTimer;

	public float attackTimer;
	public int attackCooldown = 4;

	public static bool isPlayerAlive = true; //Set to false in script with player health when player health = 0.
											// Use --> EnemyAIScript.isPlayerAlive = false;

	// Use this for initialization
	void Start () {

		waitTimer = Random.Range (2f, 4f);
		wanderTimer = 0;

		spawnPoint = transform.position;
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (isPlayerAlive) {

			if (attackTimer > 0)
				attackTimer -= Time.deltaTime;

			if (attackTimer < 0)
				attackTimer = 0;

			playerDistance = Vector3.Distance (Player.position, transform.position);

			if(playerDistance >= 8f)
			{
				moveSpeed = 1;
				Wander ();
				
				if(wanderTimer > 0)
					wanderTimer -= Time.deltaTime;
				
				if(wanderTimer < 0)
				{
					wanderTimer = 0;
					wandering = false;
					waitTimer = Random.Range (5f, 8f);
				}
				
				if(waitTimer > 0)
					waitTimer -= Time.deltaTime;
				
				if(waitTimer < 0)
				{
					waitTimer = 0;
					wandering = true;
					wanderTimer = Random.Range (2f, 4f);
				}
				
				//			if(waitTimer == 0)
				//				wanderTimer = Random.Range (2f, 4f);
				//			
				//			if(wanderTimer == 0)
				//				waitTimer = Random.Range (5f, 8f);
				
				if(wandering == false)
					wanderTimer = 0;
				
				if(wandering == true)
					waitTimer = 0;
			}
		
			if (playerDistance < 8f) 
			{
				moveSpeed = 2;
				LookAtPlayer ();
			}
	
			if (playerDistance < 6f) 
			{
				if (playerDistance > 2f) 
				{
					ChasePlayer ();
				}
				else if (playerDistance < 2f && attackTimer == 0)
				{
					Attack ();
				}
			}
		}

	}

	void LookAtPlayer()
	{
		Quaternion rotation = Quaternion.LookRotation (Player.position - transform.position);
		transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * rotationDamping);
	}

	void ChasePlayer()
	{
		transform.Translate (Vector3.forward * moveSpeed * Time.deltaTime);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Weapon") 
		{
			HP--;
			if (HP <= 0)
				gameObject.SetActive (false);
		}
	}

	void Attack()
	{

			RaycastHit hit;
			if (Physics.Raycast (transform.position, transform.forward, out hit)) 
			{
				if (hit.collider.gameObject.tag == "Player")
				{
					hit.collider.gameObject.GetComponent<HealthScript>().currentHealth -= 1;
					attackTimer = attackCooldown;
				}
			}

	}

	void Wander()
	{
		if (wanderTimer > 0) {
			
			if (transform.position == spawnPoint) 
			{
				Quaternion rotation = Quaternion.LookRotation (Player.position - transform.position);
				transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * rotationDamping);
				transform.Translate (Vector3.forward * moveSpeed * Time.deltaTime);
			} 
			else 
			{
				Quaternion rotation = Quaternion.LookRotation (spawnPoint - transform.position);
				transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * rotationDamping);
				transform.Translate (Vector3.forward * moveSpeed * Time.deltaTime);
				if(transform.position == spawnPoint)
				{
					wanderTimer = -0.1f;
				}
			}
		}
	}

}
