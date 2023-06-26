using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    public static NPCManager Instance { get; private set; } = null;
    public List<BaseNPC> RegisteredNPC { get; private set; } = new List<BaseNPC>();

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

    }

    public void RegisterNPC(BaseNPC toRegister)
    {
        RegisteredNPC.Add(toRegister);
    }

    public void DeregisterNPC(BaseNPC toDeregister)
    {
        RegisteredNPC.Remove(toDeregister);
    }
}
