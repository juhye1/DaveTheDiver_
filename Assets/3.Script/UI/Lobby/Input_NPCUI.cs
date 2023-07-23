using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Input_NPCUI : UIInput
{
    private NPC_Cobra cobra;

    private void Start()
    {
        cobra = GetComponent<NPC_Cobra>();
    }
    public override void MoveUI(Vector2 dir)
    {
        //¾ø¾î
    }

    public override void Space()
    {
        cobra.Talk();
    }
}
