using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class Fish : MonoBehaviour
{
    public enum EFishState
    {
        swim, sprint, die 
    }
    private SkeletonAnimation skeletonAnimation;
    private EFishState fishState;

    [SpineAnimation]
    public string runAnimationName;

    private void Awake()
    {
        skeletonAnimation = GetComponent<SkeletonAnimation>();
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
        skeletonAnimation.loop = true;
        skeletonAnimation.timeScale = 1;
    }

    public void Fishing(Transform harpoon)
    {
        transform.SetParent(harpoon);
        transform.localPosition = Vector3.zero;
    }

}
