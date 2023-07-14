using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseInformation :ScriptableObject
{
    public string Name;
    public InventoryManager.EType Type;
    public Sprite Face;
}
