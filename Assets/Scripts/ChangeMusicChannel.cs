using UnityEngine;
using System.Collections;

public class ChangeMusicChannel : MonoBehaviour {

	public AudioSource ThisMusic;
	public AudioSource OtherMusic1;
	public AudioSource OtherMusic2;
	public AudioSource OtherMusic3;
	public AudioSource OtherMusic4;
	//bool triggered=false;
	//float timer=0;
	public float volume=1;

	/*
	void Update(){
		if (triggered) {
			ThisMusic.volume += Time.deltaTime;
			OtherMusic1.volume -= Time.deltaTime;
			OtherMusic2.volume -= Time.deltaTime;
			OtherMusic3.volume -= Time.deltaTime;
			OtherMusic4.volume -= Time.deltaTime;
		}
		if (timer > 1) {
			triggered = false;
			ThisMusic.volume=1;
			OtherMusic1.volume=0;
			OtherMusic2.volume=0;
			OtherMusic3.volume=0;
			OtherMusic4.volume=0;
		}
		timer += Time.deltaTime;
	}*/

	void OnTriggerEnter(){
		/*triggered = true;
		timer = 0;*/

		ThisMusic.volume=volume;
		OtherMusic1.volume=0;
		OtherMusic2.volume=0;
		OtherMusic3.volume=0;
		OtherMusic4.volume=0;
	}
}
