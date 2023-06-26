using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteraction : BaseInteraction
{
    private DialogueUI dialogueUI;
    private BaseNPC npc;
    private void Start()
    {
        npc = GetComponent<BaseNPC>();
        IsStart = false;
    }
    public override void Perform()
    {
        npc.Talk();
    }

}
