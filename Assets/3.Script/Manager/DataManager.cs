using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance { get; private set; } = null;
    [SerializeField] private Dialogue dialogue;
    private Dictionary<EType, DialogueData[]> dialogueDictionary;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
            Destroy(gameObject);

        dialogueDictionary = new Dictionary<EType, DialogueData[]>();
        dialogueDictionary.Add(EType.Cobra_Gun, dialogue.dataArray);

        for (int i=0; i<dialogue.dataArray.Length; i++)
        {
            dialogueDictionary.Add(dialogue.dataArray[i].ETYPE, dialogue.dataArray);
        }
    }

    public DialogueData[] LoadData(EType key)
    {
        return dialogueDictionary[key];
    }

}
