using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public abstract class BaseNPC : MonoBehaviour
{
    protected Animator animator;
    protected DialogueUI dialogueUI;
    protected DialogueData[] dialogueDatas;
    protected DialogueData dialogueData;

    protected string dialogueString;
    protected int dialogueNum;
    protected ETalk ETalkType = ETalk.Start;


    private void Awake()
    {
        dialogueNum = 0;
        animator = GetComponent<Animator>();
    }
    private void Start()
    {
        NPCManager.Instance.RegisterNPC(this);
    }

    public abstract void RandomAnimation();

    public virtual void Talk()
    {
        switch (ETalkType)
        {
            case ETalk.Start:
                UIManager.Instance.TalkStart();
                dialogueUI = FindObjectOfType<DialogueUI>();
                dialogueUI.Talk(dialogueData);
                dialogueNum++;
                ETalkType = ETalk.InProgress;
                break;

            case ETalk.InProgress:
                dialogueUI.Talk(dialogueData);
                dialogueNum++;
                Debug.Log("¥Î»≠¡ﬂ");
                break;
            case ETalk.End:
                break;
        }

    }
}
