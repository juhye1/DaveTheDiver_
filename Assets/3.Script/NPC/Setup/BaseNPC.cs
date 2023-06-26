using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseNPC : MonoBehaviour
{
    protected Animator animator;
    protected DialogueUI dialogueUI;

    protected string dialogueKey;


    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void Start()
    {
        NPCManager.Instance.RegisterNPC(this);
    }

    public abstract void RandomAnimation();

    public virtual void Talk()
    {
        UIManager.Instance.TalkStart();
        dialogueUI = FindObjectOfType<DialogueUI>();
    }
}
