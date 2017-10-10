using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class SelectFreakScript : MonoBehaviour {

	public Text winText;			// The text space that will display "You Won".
	public Transform player; 		// The player itself.
	public Transform sam;			// The freak you choose, that is right.
	public Transform ted;			// The freak you choose, that is right.

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {

		if (Vector3.Distance (player.position, sam.position) < 5f) { 
			if (Input.GetKey (KeyCode.Space)) {
				winText.text = "You Won! You guessed right!";
			} 
		}

		if (Vector3.Distance (player.position, ted.position) < 5f) { 
			if (Input.GetKey (KeyCode.Space)) {
				winText.text = "You Lose! You guessed incorrectly!";
			} 
		}

	}
}
