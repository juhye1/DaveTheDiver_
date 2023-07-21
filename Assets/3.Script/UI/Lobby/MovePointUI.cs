using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovePointUI : UIBase
{
    [SerializeField] private GameObject SushiGO;
    [SerializeField] private GameObject DiveGO;

    [SerializeField] private Image BoatImage;
    [SerializeField] private Sprite NormalBoat;
    [SerializeField] private Sprite ActiveBoat;

    private Input_MovePointUI inputMovePointUI;

    private Color color;
    private Color defaultColor;

    private void Awake()
    {
        inputMovePointUI = GetComponent<Input_MovePointUI>();
        inputKeyUI = FindObjectOfType<InputKeyUI>();
        SushiGO.SetActive(false);
        BoatImage.sprite = NormalBoat;
        defaultColor = BoatImage.color;
        color = BoatImage.color;
        color.a = 1;

        
    }

    public void OnBoatUI(bool isOn)
    {
        if (isOn)
        {
            BoatImage.transform.localScale = Vector3.one * 1.5f;
            BoatImage.sprite = ActiveBoat;
            BoatImage.color = color;
            inputMovePointUI.SetType(Input_MovePointUI.EType.Sushi);
            UIInputManager.Instance.SetInputUI(inputMovePointUI);
            //UIInputManager.Instance.SetUIState(UIInputManager.EState.EnterUI);
        }
        else
        {
            BoatImage.transform.localScale = Vector3.one * 1.2f;
            BoatImage.sprite = NormalBoat;
            BoatImage.color = defaultColor;
        }
    }

    public void OnDiveUI(bool isON)
    {
        if (isON)
        {
            inputMovePointUI.SetType(Input_MovePointUI.EType.Dive);
            UIInputManager.Instance.SetInputUI(inputMovePointUI);

        }
        inputKeyUI.OnBG(isON);
        DiveGO.SetActive(isON);
    }
    public void OnSushiUI()
    {
        //이거 키고 포인트 바꾸고
        //여기서 한 번 더 누르면 씬 로드
        SushiGO.SetActive(true);

    }

    public override void OFFUI()
    {
        SushiGO.SetActive(false);
        inputKeyUI.UIOn(true);
    }
}
