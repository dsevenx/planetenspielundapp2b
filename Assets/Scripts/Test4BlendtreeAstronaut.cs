using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test4BlendtreeAstronaut : StateMachineBehaviour
{

	private  VirtualLookSteuerung mVirtualLookSteuerung;

	private  Himmelskoerperverwalter mHimmelskoerperverwalter;

	private Himmelskoerper mHimmelskoerper;

	// OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter (Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		init ();
	}

	void init ()
	{
		if (mVirtualLookSteuerung == null || mHimmelskoerperverwalter == null) {
			
			mVirtualLookSteuerung = GameObject.FindGameObjectWithTag ("VirtualLookSteuerung").GetComponent<VirtualLookSteuerung> ();

			mHimmelskoerperverwalter = GameObject.FindGameObjectWithTag ("HimmelskoerperverwalterOben").GetComponent<Himmelskoerperverwalter> ();

			mHimmelskoerper = GameObject.FindGameObjectWithTag ("Himmelskoerper").GetComponent<Himmelskoerper> ();


		}
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate (Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		init ();

		int lState = mVirtualLookSteuerung.getGameMode ();

		if (lState == VirtualLookSteuerung.K_GAME_MODE_LERNEN
		    || lState == VirtualLookSteuerung.K_GAME_MODE_LERNEN_LAEUFT) {

			if (mHimmelskoerper.istSchwarzeLochAktivePlanet ()) {
				animator.SetFloat ("xFloatD7X", 3);
				animator.SetFloat ("yFloatD7X", 0);
			} else if (mVirtualLookSteuerung.istStartLernen ()) {
				animator.SetFloat ("xFloatD7X", 0);
				animator.SetFloat ("yFloatD7X", 1);
			} else {
				animator.SetFloat ("xFloatD7X", 0);
				animator.SetFloat ("yFloatD7X", 0);
			}    
		} else if (lState == VirtualLookSteuerung.K_GAME_MODE_QUARTETT
		           || lState == VirtualLookSteuerung.K_GAME_MODE_QUARTETT_LAEUFT) {

			if (mHimmelskoerperverwalter.istStartQuartett ()) {
				animator.SetFloat ("xFloatD7X", 0);
				animator.SetFloat ("yFloatD7X", 0);
			} else {
				if (mHimmelskoerperverwalter.lieferletzenWinner ().Equals (Himmelskoerperverwalter.K_WIN_YOU)) {
					if (mHimmelskoerperverwalter.istDritteQuartett ()) {
						animator.SetFloat ("xFloatD7X", 2); // kleine
						animator.SetFloat ("yFloatD7X", 2);
					} else {
						animator.SetFloat ("xFloatD7X", 2); // sehr auffällig
						animator.SetFloat ("yFloatD7X", 0);
					}
				} else if (mHimmelskoerperverwalter.lieferletzenWinner ().Equals (Himmelskoerperverwalter.K_WIN_EINSTEIN)) {
					if (mHimmelskoerperverwalter.istDritteQuartett ()) {
						animator.SetFloat ("xFloatD7X", 1);
						animator.SetFloat ("yFloatD7X", 0);
					} else {
						animator.SetFloat ("xFloatD7X", 1);
						animator.SetFloat ("yFloatD7X", 1);
					}
				} else {
					animator.SetFloat ("xFloatD7X", 0);
					animator.SetFloat ("yFloatD7X", 0);
				}
			}
		} else if (lState == VirtualLookSteuerung.K_GAME_MODE_QUARTETT_WINNER_EINSTEIN) {

			animator.SetFloat ("xFloatD7X", 1);
			animator.SetFloat ("yFloatD7X", 2);

		} else if (lState == VirtualLookSteuerung.K_GAME_MODE_QUARTETT_WINNER_YOU) {

			animator.SetFloat ("xFloatD7X", 2);
			animator.SetFloat ("yFloatD7X", 1);

		} else if (lState == VirtualLookSteuerung.K_GAME_MODE_INIT) {
			animator.SetFloat ("xFloatD7X", 0);
			animator.SetFloat ("yFloatD7X", 0);
		} else {
			animator.SetFloat ("xFloatD7X", 0);
			animator.SetFloat ("yFloatD7X", 0);
		}
	}


	// OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	//override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	//override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

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
