using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CobraAnimator : StateMachineBehaviour
{
    private BaseNPC cobra;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        cobra = animator.GetComponent<BaseNPC>();
        cobra.RandomAnimation();
    }

}
