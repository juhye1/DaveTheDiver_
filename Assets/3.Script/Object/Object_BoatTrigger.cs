using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Object_BoatTrigger : BaseObject
{
    public override void Interaction()
    {
/*        if (inputKeyUI == null)
        {
            inputKeyUI = FindObjectOfType<InputKeyUI>();
        }
        switch(state)
        {
            case EState.Off:
                movePointUI.OnSushiUI();
                Point.position = newpoint;
                state = EState.On;
                break;
            case EState.On:
                inputKeyUI.UIOn(false);
                player.ActionMapDisable();
                GameManager.Instance.LoadScene(GameManager.EScene.Sushi);
                //여기서 ESC 누르면 OFF로 가야되고
                //한 번 더 누르면 씬 넘기기
                Debug.Log("씬넘겨용");
                break;



        }*/
    }

    private void Update()
    {
        if(player.State.Equals(Player.EState.Lobby))
        movePointUI.OnBoatUI(movePoint);
        //UIOn(on);
    }

}
