using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public class O2UI : MonoBehaviour
{
    [Header("O2UI")]
    [SerializeField] private Slider O2Slider;
    [SerializeField] private Image O2Image;
    [SerializeField] private TextMeshProUGUI O2TMP;
    [SerializeField] private TextMeshProUGUI DepthTMP;
    [SerializeField] private TextMeshProUGUI WeightTMP;
    [Header("Warning")]
    [SerializeField] private GameObject WarningUI;
    [SerializeField] private Volume WarningVolume;
    private Vignette vignette;

    private float O2 = 115;
    private float weight;
    private float depth;
    private float intensity;
    private int intO2;
    private bool isWarning = false;
    private bool isGoal = false;
    private Player_Underwater player;
    private Sequence warningRedFade;
    //내려갈수록 깊이 체크
    //물고기 들어있는 만큼 무게 체크
    //산소 줄이기
    private void Start()
    {
        WarningVolume.profile.TryGet(out vignette);
        WarningVolume.enabled = false;
        WarningUI.SetActive(false);

        player = FindObjectOfType<Player_Underwater>();
        O2TMP.text = O2.ToString();
        warningRedFade = DOTween.Sequence().Pause().SetLoops(10, LoopType.Yoyo);
        warningRedFade.Append(O2Image.DOColor(Color.white, 0.5f))
                      .Append(O2Image.DOColor(Color.red, 0.5f));
        intensity = 0;

        
    }

    private void Update()
    {
        UpdateUI();
        VignetteEffect();


    }


    private void UpdateUI()
    {
        //Depth
        depth = player.Depth;
        DepthTMP.text = depth.ToString("F1");
        //O2
        if(!player.Dash)
        O2 -= Time.deltaTime;
        else
        {
            //대시쓰면 빨리 닳기
            O2 -= Time.deltaTime * 10;
        }

        O2 = Mathf.Clamp(O2, 0, 120);
        O2Slider.value = O2;
        intO2 = Mathf.RoundToInt(O2);
        O2TMP.text = intO2.ToString();
        weight = InventoryManager.Instance.ReturnWeight();
        WeightTMP.text = $"{weight.ToString("F1")}/9.0kg";
        //O2 Color
        if (intO2 <= 40)
        {
            if (intO2 == 40 || !WarningUI.activeSelf)
            {
                
                Warning();
            }
        }



    }

    private void VignetteEffect()
    {
        if (!isWarning) return;

        if (isGoal)
        {
            intensity = Mathf.MoveTowards(intensity, 0, Time.deltaTime*0.5f);
            if (intensity == 0)
            {
                isGoal = !isGoal;
            }
        }
        else
        {
            intensity = Mathf.MoveTowards(intensity, 0.4f, Time.deltaTime*0.5f);
            if (intensity == 0.4f)
            {
                SoundManager.Instance.PlaySE(ESE.UI_Ingame_GoUp);
                isGoal = !isGoal;
            }

        }
        vignette.intensity.value = intensity;
    }

    private void Warning()
    {
        isWarning = true;
        WarningUI.SetActive(true);
        O2Image.color = Color.red;
        warningRedFade.Play();
        WarningVolume.enabled = true;
    }

}
