using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlMethod : MonoBehaviour {
	public bool joystick=false;
	// Use this for initialization
	void Start () {
		
	}

	public void ControlMethodScript(){
		if (joystick) {
			if (Input.GetAxis ("Mouse X") != 0f
				|| Input.GetAxis ("Mouse Y") != 0f
				|| Input.GetAxis("Fire1")!=0f
				|| Input.GetAxis("Fire2")!=0f
				|| Input.GetAxis("Fire3")!=0f
				|| Input.GetAxis ("Horizontal") != 0f
				|| Input.GetAxis ("Vertical") != 0f) {
				joystick = false;
				Debug.Log ("klavye gecildi");

			}
		} else {
			if ( ((Input.GetAxis ("Mouse X_Pad")  <1.1f && Input.GetAxis ("Mouse X_Pad")  >-1.1f) && (Input.GetAxis ("Mouse X_Pad")>0.1f || Input.GetAxis ("Mouse X_Pad")<-0.1f))
				|| ((Input.GetAxis ("Mouse Y_Pad")  <1.1f && Input.GetAxis ("Mouse Y_Pad")  >-1.1f) && (Input.GetAxis ("Mouse Y_Pad")>0.1f || Input.GetAxis ("Mouse Y_Pad")<-0.1f))
				|| Input.GetAxis("Fire1_Pad")!=0f
				|| Input.GetAxis("Fire2_Pad")!=0f
				|| Input.GetAxis("Fire3_Pad")!=0f
				|| Input.GetAxis ("Horizontal_Pad") != 0f
				|| Input.GetAxis ("Vertical_Pad") != 0f) {
				joystick = true;
				Debug.Log ("joy pad'e gecildi");

			}


		}
	
	}

	// Update is called once per frame
	void Update () {
		
	}
}
