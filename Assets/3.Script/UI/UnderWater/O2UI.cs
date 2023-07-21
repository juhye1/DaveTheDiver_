using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class O2UI : MonoBehaviour
{
    [SerializeField] private Slider O2Slider;
    [SerializeField] private Image O2Image;
    [SerializeField] private TextMeshProUGUI O2TMP;
    [SerializeField] private TextMeshProUGUI DepthTMP;
    [SerializeField] private TextMeshProUGUI WeightTMP;

    private float O2 = 115;
    private float weight;
    private float depth;
    private int intO2;
    private Player_Underwater player;
    //내려갈수록 깊이 체크
    //물고기 들어있는 만큼 무게 체크
    //산소 줄이기
    private void Start()
    {
        player = FindObjectOfType<Player_Underwater>();
        O2TMP.text = O2.ToString();
    }

    private void Update()
    {
        UpdateUI();
    }


    private void UpdateUI()
    {
        //Depth
        depth = player.Depth;
        DepthTMP.text = depth.ToString("F1");
        //O2
        O2 -= Time.deltaTime;
        O2Slider.value = O2;
        intO2 = Mathf.RoundToInt(O2);
        O2TMP.text = intO2.ToString();
        weight = InventoryManager.Instance.ReturnWeight();
        //O2 Color
        if (intO2<50)
        {
            O2Image.color = Color.red;
        }

        WeightTMP.text = $"{weight.ToString("F1")}/9.0kg";

        
    }

}
