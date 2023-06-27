using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance = null;
    [SerializeField] GameObject dialogueUI;
    [SerializeField] GameObject chapterUI;
    [SerializeField] GameObject mainUI;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else Destroy(gameObject);
    }
    private void Start()
    {
        dialogueUI.SetActive(false);
        chapterUI.SetActive(false);
    }
    public void TalkStart(bool isOn)
    {
        dialogueUI.SetActive(isOn);
        mainUI.SetActive(!isOn);
    }



    public void ShowChapter()
    {
        mainUI.gameObject.SetActive(false);
        chapterUI.gameObject.SetActive(true);
    }
}
