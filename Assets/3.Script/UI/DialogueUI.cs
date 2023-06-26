using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

[System.Serializable]
public struct Speaker
{
    public Image Portrait;
    public TextMeshProUGUI TalkBox;
    public TextMeshProUGUI NameBox;
    public Transform Panel;
}

public class DialogueUI : UIBase
{
    [SerializeField] private Speaker[] speaker;
    private PortraitData portraitData;
    private DialogueData dialogueData;
    private string dialoueText;

    private EName Ename = EName.Unknown;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        portraitData = GetComponentInChildren<PortraitData>();
        canvasGroup.alpha = 0;
    }

    private void OnEnable()
    {
        canvasGroup.DOFade(1, 0.5f);
    }

    public void TalkEffect(int num)
    {
        sequence = DOTween.Sequence();
        sequence.Append(speaker[num].Panel.DOLocalMoveY(10, 1).SetEase(Ease.OutBack)).SetDelay(0.5f)
                .Append(speaker[num].TalkBox.DOText(dialoueText.Replace("\\n", "\n"), 1f));
    }

    public void UpdateUI(string key)
    {
        dialogueData = DataManager.Instance.LoadData(key);
        dialoueText = dialogueData.Dialogtext;
        int num = dialogueData.Isnpc ? 0 : 1;
        speaker[num].NameBox.text = dialogueData.Name;
        speaker[num].TalkBox.text = string.Empty;
        speaker[num].Portrait.sprite = portraitData.PortraitDictionary[dialogueData.EEMOTIONTYPE];

        int change = num == 0 ? 1 : 0;
        SetActiveUI(speaker[change], dialogueData.Isnpc);
        TalkEffect(num);
    }

    private void SetActiveUI(Speaker speaker, bool visible)
    {
        speaker.NameBox.gameObject.SetActive(visible);
        speaker.TalkBox.gameObject.SetActive(visible);

/*        Color color = speaker.Portrait.color;
        color.a = visible ? 1 : 0.2f;
        speaker.Portrait.color = color;*/
    }



}
