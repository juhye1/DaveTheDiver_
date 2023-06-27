using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteraction : BaseInteraction
{
    private BaseObject baseObject;

    private void Start()
    {
        baseObject = GetComponent<BaseObject>();
    }
    public override void Perform()
    {
        
    }
}
