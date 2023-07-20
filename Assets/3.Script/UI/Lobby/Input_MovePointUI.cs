using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Input_MovePointUI : UIInput
{
    public enum EState
    {
        Off, On
    }

    private EState state = EState.Off;
    private MovePointUI movePointUI;
    private void Start()
    {
        movePointUI = GetComponent<MovePointUI>();
    }
    public override void MoveUI(Vector2 dir)
    {
        //얜 움직이는거 없어용
    }

    public override void Space()
    {

        switch (state)
        {
            case EState.Off:
                movePointUI.OnSushiUI();
                UIInputManager.Instance.SetUIState(UIInputManager.EState.OnUI);
                state = EState.On;
                break;
            case EState.On:
                GameManager.Instance.LoadScene(GameManager.EScene.Sushi);
                Debug.Log("씬넘겨용");
                break;
        }

        
    }

    public override void CancelUI()
    {
        base.CancelUI();
        state = EState.Off;
    }
}
