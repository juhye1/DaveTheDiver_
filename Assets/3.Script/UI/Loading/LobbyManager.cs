using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyManager : MonoBehaviour
{
    private GameManager.EScene scene => GameManager.Instance.Scene;

    private void Awake()
    {
        switch(scene)
        {
            case GameManager.EScene.UnderWaterToLobby:
                UIManager.Instance.DiveLog();
                //이거면 UI 뜨는거랑 반초한테 보내는거
                break;
            case GameManager.EScene.SushiToLobby:
                //이거는 아무일도 일어나지않는듯?
                break;
        }
    }
}
