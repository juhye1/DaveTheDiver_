using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Cobra : BaseNPC
{
    private readonly int beer = Animator.StringToHash("Beer");
    private readonly int idle = Animator.StringToHash("Idle");
    private string CobraGun = "Cobra_Gun_";
    private int dialogueNum = 0;

    public override void RandomAnimation()
    {
        int num = Random.Range(0, 2);

        switch (num)
        {
            case 0:
                animator.SetTrigger(beer);
                break;
            case 1:
                animator.SetTrigger(idle);
                break;

        }


    }

    public override void Talk()
    {
        dialogueKey = CobraGun + dialogueNum;
        base.Talk();
        dialogueUI.UpdateUI(dialogueKey);
        dialogueUI.FirstTalk();
        dialogueNum++;

    }
}
