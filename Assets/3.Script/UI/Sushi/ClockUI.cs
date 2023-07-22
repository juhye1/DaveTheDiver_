using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class ClockUI : MonoBehaviour
{
    public enum EClock
    {
        Morning,
        Afternoon,
        Evening
    }
    [SerializeField] private Slider clockSlider;
    [SerializeField] private RectTransform pointer;
    [SerializeField] private GameObject redImage;
    [Header("½Ã°£")]
    [SerializeField] private Image ClockImage;
    [SerializeField] private Sprite Morning;
    [SerializeField] private Sprite Afternoon;
    [SerializeField] private Sprite Evening;
    private bool start => SushiGameManager.Instance.isGameStart;
    private float timer;
    private void Awake()
    {
        pointer.pivot = new Vector2(0.5f, 0.1f);
        timer = pointer.localEulerAngles.z;
    }


    private void Update()
    {
        if(start)
        {
            UpSlider();
        }
    }

    private void UpSlider()
    {
        if (clockSlider.value.Equals(1))
        {
            redImage.SetActive(false);
            SushiGameManager.Instance.SushiGameEnd();
            return;
        }


        clockSlider.value = Mathf.MoveTowards(clockSlider.value, 1, Time.deltaTime * 0.005f);
        if(clockSlider.value>0.8f)
        {
            redImage.SetActive(true);
        }
        timer = Mathf.MoveTowards(timer, 0, Time.deltaTime * 20);
        pointer.localEulerAngles = new Vector3(0, 0, timer);
    }

    public void SetTime(EClock clock)
    {
        switch(clock)
        {
            case EClock.Morning:
                break;
            case EClock.Afternoon:
                break;

            case EClock.Evening:
                break;


        }
    }

}
