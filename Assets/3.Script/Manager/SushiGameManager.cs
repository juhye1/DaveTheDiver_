using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SushiGameManager : Singleton<SushiGameManager>
{
    [SerializeField] private Sprite Perfect;
    [SerializeField] private Sprite Good;
    [SerializeField] private Sprite Bad;


    [SerializeField] private GameObject SushiGO;
    [SerializeField] private CloseUI closeUI;
    [SerializeField] private ClockUI clockUI;
    [SerializeField] private OpenUI openUI;

    [SerializeField] private Image Sushi;
    [SerializeField] private CustomerSpawner customerSpawner;

    public bool isGameStart { get { return _start; } private set { } }
    private EState state = EState.End;
    public EState State => state;
    private bool _start = false;
    [HideInInspector]
    public enum EScore
    {
        Perfect,
        Good,
        Bad
    }

    public enum EState
    {
        Start, End
    }

    public EScore Score;
    private void Awake()
    {

        SushiGO.SetActive(false);
        GameManager.Instance.ResetLoadSceneEffect();
        //GameManager.Instance.LoadSceneEffect();
    }

    private void Start()
    {
        SoundManager.Instance.PlayBGM(EBGM.Sushi);
        openUI.gameObject.SetActive(true);
    }

    public void ActiveOpenUI(bool on)
    {
        openUI.gameObject.SetActive(on);

    }

    public EScore TeaScore(int score)
    {
        if (score < 50)
        {
            Score = EScore.Bad;
        }
        else if (score < 150)
        {
            Score = EScore.Good;
        }
        else if (score < 200)
        {
            Score = EScore.Perfect;
        }
        else
            Score = EScore.Good;

        return Score;
    }

    public ESE ReturnScoreSFX(EScore score)
    {
        ESE ese = ESE.Sushi_Tea_Perfect;
        switch(score)
        {
            case EScore.Perfect:
                
                break;
            case EScore.Good:
                ese = ESE.Sushi_Tea_Good;
                break;
            case EScore.Bad:
                ese = ESE.Sushi_Tea_Bad;
                break;

        }
        return ese;
    }



    public Sprite ScoreImage(int score)
    {
        EScore Escore = TeaScore(score);

        Sprite img = Perfect;
        switch(Escore)
        {
            case EScore.Perfect:
                img = Perfect;
                break;
            case EScore.Good:
                img = Good;
                break;
            case EScore.Bad:
                img = Bad;
                break;
        }
        return img;
    }

    public void OnSushi(Sprite sprite)
    {
        //반초
        SushiGO.SetActive(true);
        Sushi.sprite = sprite;
    }

    public void DumpSushi()
    {
        //스시버리기
        SushiGO.SetActive(false);
    }

    public void OpenSushi()
    {
        //게임시작
        state = EState.Start;
        UIInputManager.Instance.SetUIState(UIInputManager.EState.DisableUIInput);
        openUI.OpenSushi();
    }

    public bool DeliverSushi(Sprite sprite)
    {
        if(Sushi.sprite.name.Equals(sprite.name))
        {
            SushiGO.SetActive(false);
            return true;
        }

        return false;

    }

    public void SushiGameStart()
    {
        _start = true;
        customerSpawner.gameObject.SetActive(true);
    }
    public void SushiGameEnd()
    {

        _start = false;
        state = EState.End;
        UIInputManager.Instance.SetUIState(UIInputManager.EState.EnterUI);
        customerSpawner.gameObject.SetActive(false);
        clockUI.enabled = false;
        closeUI.OFFSushi();

    }
    public void UpdateCustomer(Customer customer)
    {
        customerSpawner.UpdateCustomer(customer);
    }
}
