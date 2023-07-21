using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyManager : Singleton<LobbyManager>
{
    private GameManager.EScene scene => GameManager.Instance.Scene;

    [SerializeField] private BoxCollider2D diveLog;

    private void Awake()
    {
        GameManager.Instance.ResetLoadSceneEffect();
        SetDiveLogCollider(false);

        switch (scene)
        {
            case GameManager.EScene.UnderWaterToLobby:
                SetDiveLogCollider(true);

                //UIManager.Instance.DiveLog();
                //이거면 UI 뜨는거랑 반초한테 보내는거
                break;
            case GameManager.EScene.SushiToLobby:
                //이거는 아무일도 일어나지않는듯?
                break;
        }
    }

    public void SetDiveLogCollider(bool enabled)
    {
        diveLog.enabled = enabled;
    }
}
