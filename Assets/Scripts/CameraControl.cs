using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {
	//Bağlantılar
	public Transform ChracterPivot;
	public Transform CameraPivot;
	Quaternion FirstRotation;
	public ControlMeta CM;
	public GameObject CameraRangeSensor;
	public Transform CameraInitial;




	[Range(0f,10f)]
	public float verticalSpeedCameraSpeed=5f;
	[Range(0f,10f)]
	public float horizantalSpeedCameraSpeed=5f;
	//Camera Maximum DistanceValue
	[Range(1f,10f)]
	public float cameraMaximumDistanceValue=6f;

	public float invert_Y=-1f;//if it_is -1f not inverted Y,if it is 1f iverted Y


	//Camera Start Values
	float x_positionCamera;
	float y_positionCamera;
	float z_positionCamera;

	//rotaion angle's of camera
	public float rotation_Horizantal=0f;
	public float rotation_Vertical=0f;

	//look directin of camera on y plane
	public Vector3 LookDirection;

	void Start () {
		
		x_positionCamera=ChracterPivot.position.x;
		y_positionCamera=ChracterPivot.position.y;
		z_positionCamera=ChracterPivot.position.z-cameraMaximumDistanceValue;
		transform.position = new Vector3 (x_positionCamera, y_positionCamera, z_positionCamera);
		FirstRotation = CameraPivot.localRotation;

	}
	void FixedUpdate(){
		RangeAdjuster ();
	
	}
	public void CameraControlScript(){

		//Controller Algılama
		if (CM._ControlMethod.joystick) {
			if (((Input.GetAxis ("Mouse X_Pad") < 1.1f && Input.GetAxis ("Mouse X_Pad") > -1.1f) && (Input.GetAxis ("Mouse X_Pad") > 0.2f || Input.GetAxis ("Mouse X_Pad") < -0.2f))
				|| ((Input.GetAxis ("Mouse Y_Pad") < 1.1f && Input.GetAxis ("Mouse Y_Pad") > -1.1f) && (Input.GetAxis ("Mouse Y_Pad") > 0.1f || Input.GetAxis ("Mouse Y_Pad") < -0.1f))) {

				rotation_Horizantal += (Input.GetAxis ("Mouse X_Pad") * horizantalSpeedCameraSpeed);
				rotation_Vertical += (Input.GetAxis ("Mouse Y_Pad") * verticalSpeedCameraSpeed)*invert_Y;
				rotation_Vertical= Mathf.Clamp (rotation_Vertical, -85f, 85f);
				//right yukatı asagi
				Quaternion Q1 = Quaternion.AngleAxis (rotation_Horizantal, Vector3.up);
				Quaternion Q2 = Quaternion.AngleAxis (rotation_Vertical, Vector3.left);
				CameraPivot.localRotation = FirstRotation * Q1 * Q2;
			}



		} else {
			//Debug.Log ("Joystick Yok");
			rotation_Horizantal += (Input.GetAxis ("Mouse X") * horizantalSpeedCameraSpeed);
			rotation_Vertical += (Input.GetAxis ("Mouse Y") * verticalSpeedCameraSpeed)*(invert_Y*-1f);
			rotation_Vertical= Mathf.Clamp (rotation_Vertical, -85f, 85f);
			//right yukatı asagi
			Quaternion Q1 = Quaternion.AngleAxis (rotation_Horizantal, Vector3.up);
			Quaternion Q2 = Quaternion.AngleAxis (rotation_Vertical, Vector3.left);
			CameraPivot.localRotation = FirstRotation * Q1 * Q2;

		}
		MeasureAndAttandLookDirection ();

	}
	// Update is called once per frame
	void Update () {







	}

	public void RangeAdjuster(){
		Debug.DrawRay (transform.position, ( CameraRangeSensor.transform.position-transform.position ), Color.red);
		float RangeFromChracter = cameraMaximumDistanceValue;
		RaycastHit[] Hits=Physics.RaycastAll(CameraInitial.position,( CameraRangeSensor.transform.position-CameraInitial.position ),10f);
		if (Hits.Length > 1) {
			RaycastHit hittedClosest;
			FindRangeOfCamera (Hits, out hittedClosest);
			if (!hittedClosest.transform.CompareTag ("CameraRange")) {
			

				RangeFromChracter = (CameraRangeSensor.transform.position - hittedClosest.point).magnitude;
			}

		}

		transform.localPosition=new Vector3(0f,0f,-1f*RangeFromChracter);

	}
	public float FindRangeOfCamera(RaycastHit[] Hits,out RaycastHit hittedClosest){
	
		float max_Distance = 100f;
		int max_Distance_index=0;
		for (int i = 0; i < Hits.Length; i++) {
			float tmp = (Hits [i].point - transform.position).magnitude;
			if (max_Distance > tmp) {
			
				max_Distance = tmp;
				max_Distance_index = i;
			}
		}
		hittedClosest = Hits [max_Distance_index];
		return max_Distance;
	
	}
	public static float AngleClamping (float rotateAngle, float min, float max)
	{
		rotateAngle = rotateAngle % 360;
		if ((rotateAngle >= -360F) && (rotateAngle <= 360F)) {
			if (rotateAngle < -360F) {
				rotateAngle += 360F;
			}
			if (rotateAngle > 360F) {
				rotateAngle -= 360F;
			}			
		}
		return Mathf.Clamp (rotateAngle, min, max);
	}

	public void MeasureAndAttandLookDirection(){
	
		Vector3 tmp = ( CameraPivot.position-transform.position);
		tmp.y = 0f;
		tmp.Normalize ();
		LookDirection = tmp;
		//Debug.Log (tmp);
		//float angleToRotate=Vector3.SignedAngle(Vector3.forward,tmp,Vector3.up);
		//Debug.Log (angleToRotate);
	
	}
}
