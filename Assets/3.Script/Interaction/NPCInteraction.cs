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
        switch(npc.State)
        {
            case BaseNPC.Estate.Talk:
                npc.Talk(); break;
            case BaseNPC.Estate.Game:
                npc.Game(); break;

        }
    }

    public override bool CanPerform()
    {
        Debug.Log("?");
        return true;
    }
}
