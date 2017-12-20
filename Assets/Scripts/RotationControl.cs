using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationControl : MonoBehaviour {
	public GameObject CharacterModel;
	public ControlMeta _ControlMeta;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void RotationControlScipt(){
		//CharacterModel.transform.rotation=Quaternion.AngleAxis(_ControlMeta._KineticControl.angleToRotate,CharacterModel.transform.up);
		//CharacterModel.transform.rotation = Quaternion.Lerp (CharacterModel.transform.rotation, Quaternion.AngleAxis (_ControlMeta._KineticControl.angleToRotate, CharacterModel.transform.up),0.1f);
		SmoothRotate();
	
	}
	void SmoothRotate(){

		CharacterModel.transform.rotation = Quaternion.Lerp (CharacterModel.transform.rotation, Quaternion.AngleAxis (_ControlMeta._KineticControl.angleToRotate, CharacterModel.transform.up),0.1f);
	
	}
}
