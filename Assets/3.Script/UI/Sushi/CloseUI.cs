using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.UI;

public class CloseUI : MonoBehaviour
{
    [SerializeField] private GameObject closeUI;
    [SerializeField] private Image background;
    [SerializeField] private GameObject title;
    [SerializeField] private GameObject bancho;

    [SerializeField] private TextMeshProUGUI[] tmpTransforms;

    //까만거 스케일
    //반초도 스케일
    //글자 한줄씩 왼쪽에서 나옴

    private Sequence sequence;
    private void Start()
    {
        sequence = DOTween.Sequence().Pause().SetAutoKill();
        background.enabled = false;
        sequence.Append(background.DOFade(0.7f, 2f))
                .Append(background.DOColor(Color.black, 0.2f))
                .Append(background.DOFade(0.5f, 0.2f));

    }
    public void OFFSushi()
    {
        background.enabled = true;
        sequence.Play();
        sequence.OnComplete(() => title.SetActive(true));
    }

    public void UIEffect()
    {
        bancho.SetActive(true);
        
    }

    public void TMPEffect()
    {
        Sequence sequence = DOTween.Sequence().Pause().SetAutoKill();
        sequence.Append(tmpTransforms[0].transform.DOLocalMoveX(171, 1).SetEase(Ease.OutBounce))
                .Join(tmpTransforms[0].DOFade(1, 1))
                .Append(tmpTransforms[1].transform.DOLocalMoveX(-81, 1).SetEase(Ease.OutBounce))
                .Join(tmpTransforms[1].DOFade(1, 1))
                .Append(tmpTransforms[2].transform.DOLocalMoveX(147, 1).SetEase(Ease.OutBounce))
                .Join(tmpTransforms[2].DOFade(1, 1));
        sequence.Play();
    }

}
