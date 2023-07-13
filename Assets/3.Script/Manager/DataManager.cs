using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance { get; private set; } = null;
    [SerializeField] private Dialogue dialogue;
    private Dictionary<ENPCType, List<DialogueData>> dialogueDictionary;

    private List<DialogueData> dialogueList;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
            Destroy(gameObject);

        Init();
    }

    public List<DialogueData> LoadData(ENPCType key)
    {
        return dialogueDictionary[key];
    }

    private void Init()
    {
        dialogueDictionary = new Dictionary<ENPCType, List<DialogueData>>();
        dialogueList = new List<DialogueData>();
        for (int i = 0; i < dialogue.dataArray.Length; i++)
        {
            if (dialogue.dataArray[i].ETYPE == ENPCType.Cobra_Gun)
            {
                dialogueList.Add(dialogue.dataArray[i]);
            }
        }
        dialogueDictionary.Add(ENPCType.Cobra_Gun, dialogueList);
    }

}
