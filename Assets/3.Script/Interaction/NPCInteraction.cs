using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteraction : BaseInteraction
{
    private BaseNPC npc;
    private void Start()
    {
        npc = GetComponent<BaseNPC>();
    }
    public override void Perform()
    {
        npc.Talk();
    }

    public override bool CanPerform()
    {
        Debug.Log("?");
        return true;
    }
}
