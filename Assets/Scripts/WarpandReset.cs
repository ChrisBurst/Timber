using UnityEngine;
using System.Collections;

public class WarpandReset : MonoBehaviour {

	AudioSource WarpNoise;
	public AudioSource otherMusic;
	bool warp=false;

	// Use this for initialization
	void Start () {
		WarpNoise = GetComponent<AudioSource> ();
		otherMusic = GameObject.Find ("Music").GetComponent<AudioSource> ();
	}

	void Update(){
		if (warp && !WarpNoise.isPlaying) {
			Application.LoadLevel (0);
		}
	}
		
	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			warp = true;
			WarpNoise.Play ();
			otherMusic.Stop();
		}
	}
}
