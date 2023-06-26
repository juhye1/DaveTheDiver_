using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance { get; private set; } = null;
    [SerializeField] private Dialogue dialogue;
    private Dictionary<string, DialogueData> dialogueDictionary;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
            Destroy(gameObject);

        dialogueDictionary = new Dictionary<string, DialogueData>();
        for(int i=0; i<dialogue.dataArray.Length; i++)
        {
            dialogueDictionary.Add(dialogue.dataArray[i].Type, dialogue.dataArray[i]);
        }
    }

    public DialogueData LoadData(string key)
    {
        return dialogueDictionary[key];
    }

}
