using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Cobra : BaseNPC
{
    private readonly int beer = Animator.StringToHash("Beer");
    private readonly int idle = Animator.StringToHash("Idle");
    private Dictionary<int, DialogueData> cobraGunDictionary;
    private EType EcobraGun = EType.Cobra_Gun;
    

    private void Start()
    {
        cobraGunDictionary = new Dictionary<int, DialogueData>();
        dialogueDatas = DataManager.Instance.LoadData(EcobraGun);
        for(int i=0; i< dialogueDatas.Count; i++)
        {
            cobraGunDictionary.Add(i, dialogueDatas[i]);
        }
        
    }
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
        dialogueCount = cobraGunDictionary.Count;
        dialogueData = cobraGunDictionary[dialogueNum];
        base.Talk();
    }
}
