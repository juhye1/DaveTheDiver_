using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIManager : MonoBehaviour
{

    public enum EState
    {
        Lobby,
        Sushi,
        UnderWater
    }
    public static UIManager Instance = null;
    private Player player;
    private Slider _slider;
    [SerializeField] private EState UIState;
    [SerializeField] private Image UIBlur;

    [Header("로비")]
    [SerializeField] private GameObject dialogueUI;
    [SerializeField] private GameObject chapterUI;
    [SerializeField] private GameObject mainUI;
    [SerializeField] private Image background;
    [SerializeField] private Image loadScene;
    [SerializeField] private Slider startSlider;
    [SerializeField] private DiveLogUI diveLogUI;

    [Header("스시집")]
    [SerializeField] private GameObject ScoreUI;
    [SerializeField] private Transform KettleGoal;
    [SerializeField] private Transform Kettle;
    [SerializeField] private Slider throwSlider;
    [SerializeField] private Slider dashSlider;
    [SerializeField] private MenuUI menuUI;

    [Header("바다")]
    [SerializeField] private GameObject powerGauge;
    [SerializeField] private InfoUI infoUI;
    [SerializeField] private PauseUI pauseUI;
    [SerializeField] private BoatUI boatUI;
    [SerializeField] private InputKeyUI inputKeyUI;




    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else Destroy(gameObject);
        player = FindObjectOfType<Player>();
    }
    private void Start()
    {
        mainUI.SetActive(true);
        switch(UIState)
        {
            case EState.Lobby:
                break;
            case EState.Sushi:
                break;
            case EState.UnderWater:
                powerGauge.SetActive(false);
                break;
        }
/*        dialogueUI.SetActive(false);
        chapterUI.SetActive(false);*/
    }


    #region Lobby

    public void ShowChapter()
    {
        mainUI.gameObject.SetActive(false);
        chapterUI.gameObject.SetActive(true);
    }
    public void TalkStart(bool isOn)
    {
        player.SwitchActionMapUI(isOn, Player.EState.Lobby);
        dialogueUI.SetActive(isOn);
        mainUI.SetActive(!isOn);
    }

    public void SetBlur(bool isOn)
    {
        UIBlur.enabled = isOn;
    }

    public void DiveLog()
    { 
        player.SwitchActionMapUI(true, Player.EState.Lobby);
        SetBlur(true);
        diveLogUI.DiveLogUIOn();
    }
    public void InteractionUI(bool isOn, GameObject ui, Player.EState state=Player.EState.Lobby)
    {
        player.SwitchActionMapUI(isOn, state);
        background.enabled = isOn;
        mainUI.SetActive(!isOn);
        if(isOn)
        {
            ui.SetActive(isOn);
            ui.transform.localPosition = new Vector2(0, -1000);
            ui.transform.DOLocalMoveY(72, 1).SetEase(Ease.OutBounce); 
        }
        else
        {
            ui.transform.DOLocalMoveY(-1000, 0.5f).OnComplete(() => ui.SetActive(false));
        }
    }


    #endregion



    #region Sushi

    public void SushiUI(bool isOn, GameObject[] ui)
    {
        player.SwitchActionMapUI(isOn, Player.EState.Sushi);
        background.enabled = isOn;
        CanvasGroup group = ScoreUI.GetComponent<CanvasGroup>();
        group.alpha = 0;
        foreach (var u in ui)
        {
            u.SetActive(isOn);
        }
    }

    #region Game
    public void ScoreOn()
    {
        CanvasGroup group = ScoreUI.GetComponent<CanvasGroup>();
        group.alpha = 0;
        Spawner spawner = FindObjectOfType<Spawner>();
        Image[] scoreImg = ScoreUI.GetComponentsInChildren<Image>();
        scoreImg[1].sprite = SushiGameManager.Instance.ScoreImage(spawner.Count);
        scoreImg[1].SetNativeSize();

        ESE ese = SushiGameManager.Instance.ReturnScoreSFX(
            SushiGameManager.Instance.TeaScore(spawner.Count));
        Sequence sequence = DOTween.Sequence().SetAutoKill();
        sequence.Append(group.DOFade(0.3f, 0.1f).SetDelay(2f))
                .Append(group.DOFade(1, 0.1f)).OnComplete(() => SoundManager.Instance.PlaySE(ese));


    }
    public bool StartUI(bool isStart)
    {
        if (isStart)
        {
            startSlider.gameObject.SetActive(true);
            startSlider.value = Mathf.MoveTowards(startSlider.value, 1, Time.deltaTime * 0.5f);
        }
        else
        {
            startSlider.value = Mathf.MoveTowards(startSlider.value, 0, Time.deltaTime * 0.3f);
            if (startSlider.value.Equals(0))
            {
                startSlider.gameObject.SetActive(false);
            }
        }
        bool gauge = throwSlider.value.Equals(1) ? true : false;
        return gauge;
    }

    public void MoveKettle()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(Kettle.transform.DOLocalMove(KettleGoal.localPosition, 2))
                .Join(Kettle.transform.DOLocalRotate(KettleGoal.localEulerAngles, 2));
    }
    public bool SliderUp(bool inputKey, Player.ESlider slider)
    {

        switch (slider)
        {
            case Player.ESlider.LoadScene:
                //나중에 스페이스바 슬라이더 넣기

                break;
            case Player.ESlider.Trash:
                _slider = throwSlider;

                break;
            case Player.ESlider.Start:
                _slider = startSlider;
                break;
        }

        if (inputKey)
        {
            _slider.gameObject.SetActive(true);
            _slider.value = Mathf.MoveTowards(_slider.value, 1, Time.deltaTime * 0.5f);
        }
        else
        {
            _slider.value = Mathf.MoveTowards(_slider.value, 0, Time.deltaTime * 0.3f);
            if (_slider.value.Equals(0))
            {
                _slider.gameObject.SetActive(false);
            }
        }
        bool gauge = _slider.value.Equals(1) ? true : false;
        return gauge;


    }

    public bool ThrowUI(bool isThrow)
    {
        if (isThrow)
        {
            throwSlider.gameObject.SetActive(true);
            throwSlider.value = Mathf.MoveTowards(throwSlider.value, 1, Time.deltaTime * 0.5f);
        }
        else
        {
            throwSlider.value = Mathf.MoveTowards(throwSlider.value, 0, Time.deltaTime * 0.3f);
            if (throwSlider.value.Equals(0))
            {
                throwSlider.gameObject.SetActive(false);
            }
        }
        bool gauge = throwSlider.value.Equals(1) ? true : false;
        if(gauge)
        {
            SoundManager.Instance.PlaySE(ESE.Sushi_Dump);
        }
        return gauge;
    }
    #endregion



    #region Move
    public void DashUI(bool isDash)
    {
        if (isDash)
        {
            dashSlider.gameObject.SetActive(true);
            dashSlider.value = Mathf.MoveTowards(dashSlider.value, 0, Time.deltaTime * 0.5f);
        }
        else
        {
            dashSlider.value = Mathf.MoveTowards(dashSlider.value, 1, Time.deltaTime * 0.3f);
            if(dashSlider.value.Equals(1))
            {
                dashSlider.gameObject.SetActive(false);
            }
        }
    }
    public bool CheckDash()
    {
        if (dashSlider.IsActive())
        {
            dashSlider.transform.position = player.UIPosition.position;
            if (dashSlider.value.Equals(0)) return false;
        }
        return true;
    }
    public void EndTired()
    {
        dashSlider.value = 0.1f;
    }



    #endregion

    public void SushiMenuUI()
    {
        menuUI.OnFirstUI();
    }








    #endregion



    #region UnderWater
    public void PowerGaugeOn(bool isOn)
    {
        powerGauge.SetActive(isOn);
    }

    public void PaueUIOn(bool isOn)
    {
        //player.InputUI = pauseUI;
        pauseUI.UIOn(isOn);
        player.SwitchActionMapUI(isOn, Player.EState.UnderWater);
    }

    public void BoatUIOn()
    {
        //player.ActionMapDisable();
        boatUI.BoatUIOn();
        inputKeyUI.UIOn(false);
    }

    #endregion
}
