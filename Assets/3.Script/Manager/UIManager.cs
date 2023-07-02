using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance = null;
    private Player player;

    [SerializeField] private GameObject dialogueUI;
    [SerializeField] private GameObject chapterUI;
    [SerializeField] private GameObject mainUI;
    [SerializeField] private Image background;
    [SerializeField] private Image loadScene;
    [SerializeField] private GameObject ScoreUI;

    [SerializeField] private Transform Kettle;
    [SerializeField] private Transform KettleGoal;

    [SerializeField] private Slider dashSlider;
    [SerializeField] private Camera cam;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
        player = FindObjectOfType<Player>();
    }
    private void Start()
    {
        mainUI.SetActive(true);
/*        dialogueUI.SetActive(false);
        chapterUI.SetActive(false);*/
    }
    public void TalkStart(bool isOn)
    {
        player.SwitchActionMap(isOn, Player.EState.Ground);
        dialogueUI.SetActive(isOn);
        mainUI.SetActive(!isOn);
    }

    public void ScoreOn()
    {
        CanvasGroup group = ScoreUI.GetComponent<CanvasGroup>();
        group.alpha = 0;
        Spawner spawner = FindObjectOfType<Spawner>();
        Image[] scoreImg = ScoreUI.GetComponentsInChildren<Image>();
        scoreImg[1].sprite = ScoreManager.Instance.ScoreImage(spawner.Count);
        scoreImg[1].SetNativeSize();

        Sequence sequence = DOTween.Sequence().SetAutoKill();
        sequence.Append(group.DOFade(0.3f, 0.1f).SetDelay(2f))
                .Append(group.DOFade(1, 0.1f));


    }
    public void GotoLoadingScene()
    {
        loadScene.enabled = true;
        loadScene.DOFade(1, 3).OnComplete(()=>SceneManager.LoadScene("LoadingScene"));
    }

    public void InteractionUI(bool isOn, GameObject ui)
    {
        player.SwitchActionMap(isOn, Player.EState.Ground);
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

    public void SushiUI(bool isOn, GameObject[] ui)
    {
        player.SwitchActionMap(isOn, Player.EState.Sushi);
        background.enabled = isOn;
        CanvasGroup group = ScoreUI.GetComponent<CanvasGroup>();
        group.alpha = 0;
        foreach (var u in ui)
        {
            u.SetActive(isOn);
        }
    }

    public void MoveKettle()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(Kettle.transform.DOLocalMove(KettleGoal.localPosition, 2))
                .Join(Kettle.transform.DOLocalRotate(KettleGoal.localEulerAngles, 2));
    }

    public void ShowChapter()
    {
        mainUI.gameObject.SetActive(false);
        chapterUI.gameObject.SetActive(true);
    }

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
            dashSlider.transform.position = cam.WorldToScreenPoint(player.UIPosition.position);
            if (dashSlider.value.Equals(0)) return false;
        }
        return true;
    }


    public void EndTired()
    {
        dashSlider.value = 0.1f;
    }
}
