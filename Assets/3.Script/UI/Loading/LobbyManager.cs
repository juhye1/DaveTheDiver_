using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyManager : Singleton<LobbyManager>
{
    private GameManager.EScene scene => GameManager.Instance.Scene;
    private SpriteColorController[] spriteColorControllers;

    [Header("바다에서 올라왔을때")]
    [SerializeField] private BoxCollider2D diveLog;
    [SerializeField] private Light eveningLight;
    [SerializeField] private Light morningLight;
    private SetClockUI clockUI;


    private void Awake()
    {
        GameManager.Instance.ResetLoadSceneEffect();
        spriteColorControllers = FindObjectsOfType<SpriteColorController>();

        clockUI = FindObjectOfType<SetClockUI>();
        SetDiveLogCollider(false);

        switch (scene)
        {
            case GameManager.EScene.UnderWaterToLobby:
                morningLight.enabled = false;
                eveningLight.enabled = true;
                SetDiveLogCollider(true);
                clockUI.SetTime(SetClockUI.EClock.Evening);
                foreach (SpriteColorController c in spriteColorControllers)
                {
                    c.SetEveningColor();
                }

                //UIManager.Instance.DiveLog();
                //이거면 UI 뜨는거랑 반초한테 보내는거
                break;
            case GameManager.EScene.SushiToLobby:
                //이거는 아무일도 일어나지않는듯?
                break;
            default:
                clockUI.SetTime(SetClockUI.EClock.Morning);
                break;
        }
    }

    public void SetDiveLogCollider(bool enabled)
    {
        diveLog.enabled = enabled;
    }
}
