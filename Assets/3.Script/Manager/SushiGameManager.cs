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
    private bool _start = false;
    [HideInInspector]
    public enum EScore
    {
        Perfect,
        Good,
        Bad
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
        openUI.gameObject.SetActive(true);
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
        SushiGO.SetActive(true);
        Sushi.sprite = sprite;
    }

    public void OffSushi()
    {
        SushiGO.SetActive(false);
    }

    public void OpenSushi()
    {
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
        customerSpawner.gameObject.SetActive(false);
        clockUI.enabled = false;
        closeUI.OFFSushi();

    }
    public void UpdateCustomer(Customer customer)
    {
        customerSpawner.UpdateCustomer(customer);
    }
}
