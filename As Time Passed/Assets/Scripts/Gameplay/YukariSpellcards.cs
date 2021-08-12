using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DanmakU;
using DanmakU.Fireables;

public class YukariSpellcards : StateMachineBehaviour
{
    //GameObject emitter;

    //public void OnEnable()
    //{
    //    emitter = GameObject.Find("Boss Emitter");

    //    GameObject.Find("Boss Emitter").SetActive(false);

    //    //emitter.GetComponent<DanmakuEmitter>().FireRate = 0.0000001f;
    //}
    //// OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    if (stateInfo.IsTag("spell0"))
    //    {
    //        //emitter.GetComponent<DanmakuEmitter>().FireRate = 25f;
    //        GameObject.Find("Boss Emitter").SetActive(true);
    //    }
    //    else
    //    {
    //        //emitter.GetComponent<DanmakuEmitter>().FireRate = 0.0000001f;
    //        GameObject.Find("Boss Emitter").SetActive(false);
    //    }
    //}

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{

    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
