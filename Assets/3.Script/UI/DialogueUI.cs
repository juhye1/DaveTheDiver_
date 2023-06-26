using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public enum EEmotionType
{
    Normal = 0,
    Nice,
    Smile
}
public class DialogueUI : UIBase
{
    [SerializeField] private Transform LeftPanel;
    [SerializeField] private Transform RightPanel;

    public Image LeftPortrait;
    public Image RightPortrait;

    public TextMeshProUGUI LeftTMP;
    public TextMeshProUGUI RightTMP;
    public TextMeshProUGUI LeftNameTMP;
    public TextMeshProUGUI RightNameTMP;

    private PortraitData portraitData;
    private string dialoueText = "";
    
    private DialogueData dialogueData;
    private void Awake()
    {
        tmp = GetComponentInChildren<TextMeshProUGUI>();
        canvasGroup = GetComponent<CanvasGroup>();
        portraitData = GetComponentInChildren<PortraitData>();
        canvasGroup.alpha = 0;
    }

    private void Init()
    {
        sequence = DOTween.Sequence();
        sequence.Append(canvasGroup.DOFade(1, 0.5f))
                .Append(LeftPanel.DOLocalMoveY(10, 1).SetEase(Ease.OutBack))
                .Append(tmp.DOText(dialoueText.Replace("\\n","\n"), 1f));
    }

    public void FirstTalk()
    {
        sequence = DOTween.Sequence();
        sequence.Append(canvasGroup.DOFade(1, 0.5f))
                .Append(LeftPanel.DOLocalMoveY(10, 1).SetEase(Ease.OutBack))
                .Append(tmp.DOText(dialoueText.Replace("\\n", "\n"), 1f));
        DOTween.Play(sequence);
    }

    public void UpdateUI(string key)
    {
        dialogueData = DataManager.Instance.LoadData(key);
        dialoueText = dialogueData.Dialogtext;
        LeftNameTMP.text = dialogueData.Name;
        LeftPortrait.sprite = portraitData.PortraitDictionary[dialogueData.EEMOTIONTYPE];
    }

}
