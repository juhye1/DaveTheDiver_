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

    [Header("Evening")]
    [SerializeField] private GameObject evening;
    [SerializeField] private GameObject eveningSushi;
    [SerializeField] private Light eveningBoatLight;
    [SerializeField] private Material eveningGround;
    [SerializeField] private Color eveningGroundColor;

    [Header("Morning")]
    [SerializeField] private GameObject morning;
    [SerializeField] private GameObject morningSushi;
    private SetClockUI clockUI;


    private void Start()
    {
        GameManager.Instance.ResetLoadSceneEffect();


        SoundManager.Instance.PlayBGM(EBGM.Lobby);



        spriteColorControllers = FindObjectsOfType<SpriteColorController>();
        clockUI = FindObjectOfType<SetClockUI>();
        eveningGround.color = Color.white;
        eveningBoatLight.enabled = false;

        SetDiveLogCollider(false);
        switch (scene)
        {
            case GameManager.EScene.UnderWaterToLobby:
                //저녁으로 바꾸기

                spriteColorControllers = FindObjectsOfType<SpriteColorController>();
                foreach (SpriteColorController c in spriteColorControllers)
                {
                    c.SetEveningColor();
                }
                SoundManager.Instance.PlaySE(ESE.Lobby_Night);
                UpdateTime();
                SetDiveLogCollider(true);

                //UIManager.Instance.DiveLog();
                //이거면 UI 뜨는거랑 반초한테 보내는거
                break;
            case GameManager.EScene.SushiToLobby:
                SoundManager.Instance.PlaySE(ESE.AMB_Birds);
                SoundManager.Instance.ChangeBGMVolume(0.3f);
                clockUI.SetTime(SetClockUI.EClock.Morning);
                UIManager.Instance.ShowChapter();
                //이거는 아무일도 일어나지않는듯?
                break;

            case GameManager.EScene.Loading:
                clockUI.SetTime(SetClockUI.EClock.Morning);
                break;

        }
    }

    

    public void SetDiveLogCollider(bool enabled)
    {
        diveLog.enabled = enabled;
    }

    private void UpdateTime()
    {
        clockUI.SetTime(SetClockUI.EClock.Evening);
        //아침
        morningLight.enabled = false;
        morning.SetActive(false);
        morningSushi.SetActive(false);
        //저녁
        evening.SetActive(true);
        eveningLight.enabled = true;
        eveningBoatLight.enabled = true;
        eveningSushi.SetActive(true);
        eveningGround.color = eveningGroundColor;
    }
}
