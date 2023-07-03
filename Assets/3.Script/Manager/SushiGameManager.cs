using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SushiGameManager : MonoBehaviour
{
    [SerializeField] private Sprite Perfect;
    [SerializeField] private Sprite Good;
    [SerializeField] private Sprite Bad;


    [SerializeField] private GameObject SushiGO;
    private SpriteRenderer Sushi;

    [HideInInspector]
    public enum EScore
    {
        Perfect,
        Good,
        Bad
    }

    public static SushiGameManager Instance;
    public EScore Score;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
            Destroy(gameObject);

        Sushi = SushiGO.GetComponentInChildren<SpriteRenderer>();
        SushiGO.SetActive(false);
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
}
