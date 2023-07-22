using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class SetClockUI : MonoBehaviour
{
    public enum EClock
    {
        Morning,
        Afternoon,
        Evening
    }

    [Header("Main")]
    [SerializeField] private Image Morning;
    [SerializeField] private Image Afternoon;
    [SerializeField] private Image Evening;
    [Header("Icon")]
    [SerializeField] private Image IconImage;
    [SerializeField] private Sprite[] IconSprites;
    [SerializeField] private TextMeshProUGUI ClockTMP;

    private List<Image> images;
    private Sprite time;
    private void Awake()
    {
        images = new List<Image>();
        images.Add(Morning);
        images.Add(Afternoon);
        images.Add(Evening);

        ResetClock();
    }

    public void SetTime(EClock clock)
    {
        ResetClock();
        switch (clock)
        {
            case EClock.Morning:
                Morning.enabled = true;
                IconImage.sprite = IconSprites[0];
                ClockTMP.text = "Morning";
                break;
            case EClock.Afternoon:
                Afternoon.enabled = true;
                ClockTMP.text = "Afternoon";
                IconImage.sprite = IconSprites[1];
                break;

            case EClock.Evening:
                ClockTMP.text = "Evening";
                IconImage.sprite = IconSprites[2];
                Afternoon.enabled = true;
                Evening.enabled = true;
                Morning.enabled = true;
                break;


        }
    }

    private void ResetClock()
    {
        foreach (Image image in images)
        {
            image.enabled = false;
        }
    }
}
