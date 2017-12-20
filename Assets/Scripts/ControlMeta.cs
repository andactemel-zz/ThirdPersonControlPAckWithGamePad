using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlMeta : MonoBehaviour {
	public CameraControl _CameraControl;
	public ControlMethod _ControlMethod;
	public KineticControl _KineticControl;
	public RotationControl _RotationControl;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		_ControlMethod.ControlMethodScript ();
		_CameraControl.CameraControlScript ();
		_KineticControl.KineticControlScript ();
		_RotationControl.RotationControlScipt ();
	}
}
