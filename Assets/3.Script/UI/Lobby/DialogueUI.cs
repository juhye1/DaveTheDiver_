using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

[System.Serializable]
public struct Speaker
{
    public GameObject TalkBox;
    public CanvasGroup Group;
    public Image Portrait;
    public TextMeshProUGUI TalkTMP;
    public TextMeshProUGUI NameBox;
    public Transform Panel;
}

public class DialogueUI : MonoBehaviour
{
    protected Sequence sequence;
    protected TextMeshProUGUI tmp;
    protected CanvasGroup canvasGroup;


    [SerializeField] private Speaker[] speaker;
    private Speaker curruentSpeaker;
    private PortraitData portraitData;
    private DialogueData dialogueData;
    private string dialoueText;
    private int _num;

    private Sequence upSequence;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        portraitData = FindObjectOfType<PortraitData>();
        canvasGroup.alpha = 0; 
        _num = 1;
        upSequence = DOTween.Sequence();
    }

    private void OnEnable()
    {
        canvasGroup.DOFade(1, 0.5f);
    }

    public void UpTalkEffect()
    {
        upSequence = DOTween.Sequence().SetAutoKill()
                .Append(curruentSpeaker.Panel.DOLocalMoveY(10, 1).SetEase(Ease.OutBack))
                .Append(curruentSpeaker.TalkTMP.DOText(dialoueText.Replace("\\n", "\n"), 1f));


    }
    public void DownTalkEffect(int num)
    {
        sequence = DOTween.Sequence().SetAutoKill()
                        .Append(speaker[num].Panel.DOLocalMoveY(-30, 1));
        speaker[num].TalkTMP.text = string.Empty;
    }

    public void Talk(DialogueData data)
    {
        Speaker speaker = UpdateUI(data);
        dialoueText = data.Dialogtext;
        speaker.NameBox.text = data.Name;
        speaker.TalkTMP.text = string.Empty;
        speaker.Portrait.sprite = 
                portraitData.LoadPortrait(data.ENAME, data.EEMOTIONTYPE);
        curruentSpeaker = speaker;
        UpTalkEffect();
    }


    public Speaker UpdateUI(DialogueData data)
    {
        if(dialogueData!=null)
        {
            _num = dialogueData.Isnpc ? 0 : 1;
        }
        dialogueData = data;
        int num = dialogueData.Isnpc ? 0 : 1;

        if (_num!=num)
        {
            SetActiveUI(speaker, num);
            DownTalkEffect(_num);
            _num = num;
        }
        return speaker[num];


    }

    private void SetActiveUI(Speaker[] speaker, int num)
    {
        speaker[num].Panel.gameObject.SetActive(true);
        speaker[num].TalkBox.SetActive(true);
        speaker[num].Group.alpha = 1;

        speaker[_num].TalkBox.SetActive(false);
        speaker[_num].Group.alpha = 0.5f;
    }



}
