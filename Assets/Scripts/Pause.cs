using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {

	float pauseTimer=0;
	bool isPaused=false;
	public GameObject Player;
	public GameObject MainCamera;
	public GameObject PauseCamera;
	public GameObject PauseBackdrop;
	public GameObject HUDYellow;
	public GameObject YellowTargetON;
	public GameObject HUDBlue;
	public GameObject BlueTargetON;
	public GameObject ContinueGraphic;
	public GameObject QuitGraphic;
	bool continueSelected=true;
	bool quitSelected=false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (pauseTimer > .2f) {
			if (Input.GetKey (KeyCode.Escape)||Input.GetButtonDown("Start")) {
				isPaused = !isPaused;
				pauseTimer=0;
			}
			if(Input.GetAxisRaw("Vertical")!=0&&isPaused){
				continueSelected=!continueSelected;
				quitSelected=!quitSelected;
				pauseTimer=0;
			}
			if(Input.GetButtonDown ("Jump")&&isPaused){
				if(continueSelected)
					ContinueGame();
				if(quitSelected)
					QuitGame();
				pauseTimer=0;
			}
		}
		pauseTimer += Time.deltaTime;
		Player.SetActive (!isPaused);
		MainCamera.SetActive (!isPaused);
		PauseCamera.SetActive (isPaused);
		PauseBackdrop.SetActive (isPaused);
		if (isPaused) {
			HUDYellow.transform.position = YellowTargetON.transform.position;
			HUDBlue.transform.position = BlueTargetON.transform.position;
		}
		ContinueGraphic.SetActive (continueSelected);
		QuitGraphic.SetActive (quitSelected);
	}

	public void ContinueGame(){
		isPaused = !isPaused;
		pauseTimer=0;
	}

	public void QuitGame(){
		Application.Quit ();
	}
}
