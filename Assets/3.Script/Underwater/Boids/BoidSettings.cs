using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "BoidSettings", menuName = "ScriptableObject/BoidSettings")]
public class BoidSettings : ScriptableObject
{
    [Header("속도")]
    public float minSpeed = 2;
    public float maxSpeed = 5;

    [Header("무리를 인식하는 범위")]
    public float perceptionRadius = 2.5f;
    [Header("충돌을 인식하는 범위")]
    public float avoidanceRadius = 1;
    [Header("최대 조종력")]
    public float maxSteerForce = 3;

    [Header("가중치")]
    //무리의 평균 방향으로 조향
    public float alignWeight = 1;
    //무리의 평균 위치로 이동
    public float cohesionWeight = 1;
    //무리와 반대방향으로 이동
    public float seperateWeight = 1;

    public float targetWeight = 1;

    [Header("마스크")]
    public LayerMask obstacleMask;
    public float boundsRadius = .27f;
    public float avoidCollisionWeight = 10;
    public float collisionAvoidDst = 5;
}
