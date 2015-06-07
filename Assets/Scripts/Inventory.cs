using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

	//YELLOW
	public float yellow;
	public GameObject HUDYellow;
	public Text NumYellow;
	float yellowTimer=0;
	public GameObject YellowTargetON;
	public GameObject YellowTargetOFF;
	//BLUE
	public float blue=0;
	public GameObject HUDBlue;
	public Text NumBlue;
	float blueTimer=0;
	public GameObject BlueTargetON;
	public GameObject BlueTargetOFF;

	// Use this for initialization
	void Start () {
		NumYellow.text=yellow.ToString();
		NumBlue.text=blue.ToString();
		yellow = 0;
	}
	
	// Update is called once per frame
	void Update () {
		//YELLOW
		if (yellowTimer > 2f) {
			HUDYellow.transform.position = Vector3.MoveTowards (HUDYellow.transform.position, YellowTargetOFF.transform.position, 300 * Time.deltaTime);
		}else
			HUDYellow.transform.position = Vector3.MoveTowards(HUDYellow.transform.position, YellowTargetON.transform.position, 300*Time.deltaTime);
		yellowTimer += Time.deltaTime;

		//BLUE
		if (blueTimer > 2f) {
			HUDBlue.transform.position = Vector3.MoveTowards (HUDBlue.transform.position, BlueTargetOFF.transform.position, 300 * Time.deltaTime);
		}else
			HUDBlue.transform.position = Vector3.MoveTowards(HUDBlue.transform.position, BlueTargetON.transform.position, 300*Time.deltaTime);
		blueTimer += Time.deltaTime;
	}

	public void AddItem(string type){
		//YELLOW
		if (type == "Log") {
			yellow++;
			NumYellow.text = yellow.ToString();
			yellowTimer = 0;
		}

		//BLUE
		else if (type == "ItemBlue") {
			blue++;
			NumBlue.text = blue.ToString();
			blueTimer = 0;
		} else {
			Debug.LogError ("There is no item by the name of '" + type + "' in Timber's inventory database." +
				"Double check what you named it. If that doesn't work, contact Christopher Burst.");
		}

	}

	public void ShowItem(string type){
		if (type == "Log") {
			yellowTimer = 0;
		} else
			Debug.Log ("Item does not exist");
	}

	/*public void CheckInventory(string type){
		if (type == "Log") {
			BZone.SendMessage ("ListenEcho", yellow);
			print (yellow);
		} else
			Debug.Log ("Item does not exist");
	}*/
}
