using UnityEngine;
using System.Collections;

public class GPS : MonoBehaviour {

	string message = " ";

	IEnumerator Wait(int seconds){
				yield return new WaitForSeconds (seconds);
		}
	void OnGUI(){ //prints out words on the screen so the user can know which values correspond to latitude, longitude, and altitude
				GUI.Label (new Rect (10, 10, 400, 50), "Your coordinates are:" + message);
				GUI.Label (new Rect (10, 30, 200, 50), "Longitude: " + Input.location.lastData.longitude);
				GUI.Label (new Rect (10, 50, 200, 50), "Latitude: " + Input.location.lastData.latitude);
				GUI.Label (new Rect (10, 70, 200, 50), "Altitude: " + Input.location.lastData.altitude);
		}

	// Use this for initialization
	void Start () {
		Screen.orientation = ScreenOrientation.Portrait; //this orients the screen in portrait if a mobile device runs the code
	if (!Input.location.isEnabledByUser) { //this checks to see if GPS is enabled
						return;
				}
		Input.location.Start (5f, 5f); //checks for coordinate accuracy within 5 feet
		int maxWait = 20;

		while(Input.location.status == LocationServiceStatus.Initializing && maxWait >0)
		{ StartCoroutine(Wait (1));
			maxWait--;
		}
		if(Input.location.status == LocationServiceStatus.Failed){
			message= "Unable to determine device location."; //reports an error message if coordinates cannnot be ascertained
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
