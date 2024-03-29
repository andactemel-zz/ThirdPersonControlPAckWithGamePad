﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KineticAnimation : StateMachineBehaviour {
	public float m_Damping = 0.15f;
	public float hrznt=0;
	public float vertic=0;
	private readonly int m_HashHorizontalPara = Animator.StringToHash ("Horizontal");
	private readonly int m_HashVerticalPara = Animator.StringToHash ("Vertical");
	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	//override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		// player = GameObject.Find(“Player”);
		ControlMeta _ControlMeta=GameObject.Find("CharacterPivot").GetComponent<ControlMeta>();
		float horizontal = _ControlMeta._KineticControl.animationDirection.x;
		float vertical = _ControlMeta._KineticControl.animationDirection.z;
		hrznt = horizontal;
		vertic = vertical;
		Vector2 input = new Vector2(horizontal, vertical);

		animator.SetFloat(m_HashHorizontalPara, input.x, m_Damping, Time.deltaTime);
		animator.SetFloat(m_HashVerticalPara, input.y, m_Damping, Time.deltaTime);
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	//override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}
