using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* TO DO
 *  - Lock the mouse cursor and hide it for greater immersion
 *  
 */

public class MouseLook : MonoBehaviour {

	public float mouseSensitivity = 100f;
	float verticalLookAngle = 0f;

	// Update is called once per frame
	void Update () {
		float mouseX = Input.GetAxis ( "Mouse X" ) * Time.deltaTime * mouseSensitivity; // Horizontal mouse movement
		float mouseY = Input.GetAxis ( "Mouse Y" ) * Time.deltaTime * mouseSensitivity; // Vertical mouse movement

		//transform.Rotate (-mouseY, 0f, 0f);	// Rotate the camera (NOW UNUSED)
		transform.parent.Rotate (0f, mouseX, 0f); // Rotate the parent/cube
		// New vertical looking up/down code:
		verticalLookAngle -= mouseY;
		verticalLookAngle = Mathf.Clamp( verticalLookAngle, -89f, 89f ); // Don't let the player look straight up. Don't let them. Don't.

		// Correction pass: unroll the camera - straigten out the Z axis
//		transform.localEulerAngles.z = 0f; // THIS WILL NOT WORK BECAUSE IT'S A VECTOR3
		transform.localEulerAngles = new Vector3 (
			verticalLookAngle,				// Overriding the X andlge with my vertical look angle, always
			transform.localEulerAngles.y,	// put Y back into itself
			0f								// overriding the Z andle with 0 to unroll the camera
		);

		if (Input.GetMouseButton (0)) { // Did they left-click their mouse?
			Cursor.visible = false; // Hides the mouse cursor on click
			Cursor.lockState = CursorLockMode.Locked; // Locks the cursor in the center of the screen.
		}

	}
}
