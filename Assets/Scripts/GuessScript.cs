using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class GuessScript : MonoBehaviour {

	public Text hintText;			// The text space that will display hints.
	public Transform player; 		// The player itself.
	public Transform sam;	// The first freak.
	public Transform ted;	// The second freak.

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


		Debug.Log (Vector3.Distance (player.position, sam.position));

		if (Vector3.Distance (player.position, sam.position) < 5f ) { 
			hintText.text = "This is a freak. Do you think this freak is Sam? \n(Press Space to select this freak)"; 
		} else if ( player.position.z < -1f ) { 
			hintText.text = "Walk up to a freak."; 
		}

		if (Vector3.Distance (player.position, ted.position) < 5f ) { 
			hintText.text = "This is a freak. Do you think this freak is Sam? \n(Press Space to select this freak)"; 
		} else if ( player.position.z < -1f ) { 
			hintText.text = "Walk up to a freak."; 
		}

	}
}
