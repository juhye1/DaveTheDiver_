using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="PlayerSettings", menuName = "ScriptableObject/PlayerSettings")]
public class PlayerSettings : ScriptableObject
{
    [Header("이동")]
    public float MoveSpeed = 0.5f;
    public float DashSpeed = 0.7f;

    [Space(10)]
    [Header("상호 작용")]
    public float DetectRange;
/*    public LayerMask NPCMask;
    public LayerMask ObjectMask;*/
    public LayerMask InteractableMask;
    public LayerMask MovePointMask;


}
