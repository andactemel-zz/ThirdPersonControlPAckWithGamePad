using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KineticControl : MonoBehaviour {
	public CharacterController _CharacterController;
	public float speed = 6.0F;
	public float jumpSpeed = 8.0F;
	public float gravity = 20.0F;
	public Vector3 moveDirection = Vector3.zero;
	public Vector3 animationDirection=Vector3.zero;
	public float angleToRotate=0f;
	public ControlMeta _ControlMeta;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void KineticControlScript(){
		//_CharacterController.SimpleMove (Vector3.forward);
		if (!_ControlMeta._ControlMethod.joystick) {
			if (_CharacterController.isGrounded) {
				moveDirection = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
				moveDirection = transform.TransformDirection (moveDirection);
				animationDirection = moveDirection;
				Vector3 LookDirection = _ControlMeta._CameraControl.LookDirection;
				moveDirection= AlignMoveDirection (moveDirection, LookDirection);

				//Debug.Log (moveDirection);
				moveDirection *= speed;
				if (Input.GetButton ("Jump"))
					moveDirection.y = jumpSpeed;

			}
			moveDirection.y -= gravity * Time.deltaTime;
			_CharacterController.Move (moveDirection * Time.deltaTime);
		} else {
		
			if (_CharacterController.isGrounded) {
				moveDirection = new Vector3 (Input.GetAxis ("Horizontal_Pad"), 0, Input.GetAxis ("Vertical_Pad"));
				moveDirection = transform.TransformDirection (moveDirection);
				animationDirection = moveDirection;
				Vector3 LookDirection = _ControlMeta._CameraControl.LookDirection;
				moveDirection= AlignMoveDirection (moveDirection, LookDirection);

				//Debug.Log (moveDirection);
				moveDirection *= speed;
				if (Input.GetButton ("Jump"))
					moveDirection.y = jumpSpeed;

			}
			moveDirection.y -= gravity * Time.deltaTime;
			_CharacterController.Move (moveDirection * Time.deltaTime);
		
		}
		//Debug.Log (animationDirection);
	}

	public Vector3 AlignMoveDirection(Vector3 FirstMoveDirection,Vector3 LookDirection){
	
		 angleToRotate=Vector3.SignedAngle(Vector3.forward,LookDirection,Vector3.up);
		//Debug.Log (FirstMoveDirection);

		Vector3 tmp = Quaternion.AngleAxis (angleToRotate, Vector3.up) * FirstMoveDirection;
		//Debug.Log (tmp);
		return tmp;
	
	}
}
