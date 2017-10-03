using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyVelocity : MonoBehaviour {

	Vector3 inputVector; //take input from Update, send it into FixedUpdate for physics

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		float horizontalInput = Input.GetAxis ("Horizontal");	// A/D, LeftArrow/RightArrow
		float verticalInput = Input.GetAxis("Vertical");		// W/S, RightArrow/LeftArrow

		//Transform our input values based on this transform's "right" / "forward" directions
		inputVector = transform.right * horizontalInput + transform.forward * verticalInput;

		// Normalize the inputvector so that diagonal movement isn't faster
		if (inputVector.magnitude > 1f)
		{
			inputVector = Vector3.Normalize (inputVector);
		}

	}

	// FixedIpdate is called once per physics frame
	void FixedUpdate ()
	{
		//if (inputVector.magnitude > 0.001f)
		//{ 
			GetComponent<Rigidbody> ().velocity = inputVector * 15f + Physics.gravity * 0.8f; // Speed and gravity
		//}

	}
}
