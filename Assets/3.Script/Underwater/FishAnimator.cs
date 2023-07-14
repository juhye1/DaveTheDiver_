using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class FishAnimator : MonoBehaviour
{
    public enum EFishState
    {
        swim, sprint, die 
    }
    private SkeletonAnimation skeletonAnimation;
    private Boid boid;
    private EFishState fishState;

    [SpineAnimation]
    public string runAnimationName;

    private void Awake()
    {
        boid = GetComponent<Boid>();
        skeletonAnimation = GetComponent<SkeletonAnimation>();
        skeletonAnimation.Initialize(true);
    }

    private void Start()
    {
        SetAnimation(EFishState.swim);
    }
    private void SetAnimation(EFishState fishState)
    {
        switch(fishState)
        {
            case EFishState.swim:
                runAnimationName = "swim";
                break;
            case EFishState.sprint:
                runAnimationName = "sprint";
                break;
            case EFishState.die:
                runAnimationName = "die";
                break;

        }

        skeletonAnimation.state.SetAnimation(0, runAnimationName, true);
        //skeletonAnimation.loop = true;
        //skeletonAnimation.timeScale = 1;
    }

}
