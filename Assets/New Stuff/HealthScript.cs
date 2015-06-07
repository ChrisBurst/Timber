using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour {

	public int maxHealth;
	public int currentHealth;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (currentHealth < 0)
			currentHealth = 0;

		if (currentHealth > maxHealth)
			currentHealth = maxHealth;
	
	}
}
