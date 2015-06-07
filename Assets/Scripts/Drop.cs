using UnityEngine;
using System.Collections;

public class Drop : MonoBehaviour {

	/*Current types of drops:
	 * 
	 * Tree
	 * *66% Log
	 * *34% Log Stack
	 * 
	 * Enemy
	 * *40% Pancake
	 * *60% Nothing
	 * 
	 * More to be added
	 */

	public GameObject Coin;
	public GameObject LogStack;
	float diceRoll;

	void drop(string DropType){
		diceRoll= Random.Range (1,100);
		if (DropType=="Tree"){
			if(diceRoll>=101) //Currently Impossible
				print ("nocoin");//Instantiate(Coin, transform.position, Quaternion.identity);
			else
				Instantiate(LogStack, transform.position, Quaternion.identity);

		}else
			Debug.LogError ("There is no item or list by the name of '" + DropType + "' in Timber's drop database." +
			                "Double check what you named it. If that doesn't work, contact Christopher Burst.");

	}

}
