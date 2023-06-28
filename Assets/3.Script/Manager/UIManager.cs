using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance = null;
    [SerializeField] private GameObject dialogueUI;
    [SerializeField] private GameObject chapterUI;
    [SerializeField] private GameObject mainUI;
    [SerializeField] private Image background;

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

    public void InteractionUI(bool isOn, GameObject ui)
    {
        background.enabled = isOn;
        mainUI.SetActive(!isOn);
        ui.SetActive(isOn);
        ui.transform.localPosition = new Vector2(0, -1000);
        ui.transform.DOLocalMoveY(72, 1).SetEase(Ease.OutBounce); 
    }

    public void ShowChapter()
    {
        mainUI.gameObject.SetActive(false);
        chapterUI.gameObject.SetActive(true);
    }
}
