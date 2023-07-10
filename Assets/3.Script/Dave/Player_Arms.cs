using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Arms : MonoBehaviour
{
    private Player_Underwater player;
    private Animator child;
    [SerializeField] private Transform arrow;

    private void Awake()
    {
        player = GetComponentInParent<Player_Underwater>();
        child = GetComponentInChildren<Animator>();
        child.gameObject.SetActive(false);
    }
    public void MoveArms()
    {
        child.gameObject.SetActive(true);
        transform.rotation = Quaternion.Euler(0, 0, -arrow.localEulerAngles.z);
    }

    public void OffArms()
    {
        child.gameObject.SetActive(false);

    }
}
