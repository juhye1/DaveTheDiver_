using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class OpenUI : MonoBehaviour
{
    [SerializeField] private GameObject readyPanel;
    [SerializeField] private GameObject openPanel;
    [SerializeField] private GameObject backGround;
    [SerializeField] private ParticleSystem sushiParticle;
    private Sequence sequence;

    private void Awake()
    {
        openPanel.transform.localScale = Vector3.one * 0.1f;

        sequence = DOTween.Sequence().Pause();
        sequence.Append(openPanel.transform.DOScale(1, 0.5f).SetEase(Ease.OutBounce));

    }

    public void OpenSushi()
    {
        readyPanel.SetActive(false);
        openPanel.SetActive(true);
        sequence.Play();
        sequence.OnComplete(() => Particle());
        //ÀÌÆåÆ®
        //¼Õ´Ô ½ºÆù
    }

    private void Particle()
    {
        backGround.SetActive(true);
        sushiParticle.Play();
    }

    public void CloseUI()
    {
        openPanel.SetActive(false);
        SushiGameManager.Instance.SushiGameStart();
    }


}
