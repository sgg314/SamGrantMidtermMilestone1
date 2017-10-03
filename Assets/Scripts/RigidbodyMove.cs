using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyMove : MonoBehaviour {

	Vector3 inputVector; // Story our input from Update(), and we'll put this into physics.
	Rigidbody myRigidbody;
	float speed;

	// Use this for initialization
	void Start () {
		myRigidbody = GetComponent<Rigidbody> (); // Assign reference to RB in Start

		speed = 20; // The vehicle's speed.
	}
	
	// Update is called once per frame
	void Update () {
		float inputHorizontal = Input.GetAxis( "Horizontal" );	//Allows for smoother inputs. This is horizontal input, A/D or Left/Right
		float inputVertical = Input.GetAxis( "Vertical" );		//Allows for smoother inputs. This is vertical input, W/S or Up/Down

		transform.Rotate (0f, inputHorizontal * Time.deltaTime * 90f, 0f); //Rotate the cube

		// Put our input values into an "input vector"
		inputVector = new Vector3( 0f, 0f, inputVertical );

		// Normalize input vector3 magnitude > 1f, to avoid diagonal movement exploit
		if (inputVector.magnitude > 1f)
		{
			inputVector = Vector3.Normalize (inputVector);
		}
	}

	// Runs at a fixed framerate, which is when physics runs
	void FixedUpdate () {
		myRigidbody.AddForce ( transform.TransformDirection(inputVector) * speed );
		// How it moves, and its speed. TransformDirection makes the cube rotate and move along it's LoS
		myRigidbody.AddRelativeForce( inputVector * speed);

	}
}
