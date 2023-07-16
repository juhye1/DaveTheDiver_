using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputKeyUI : MonoBehaviour
{
    public enum EState
    {
        Lobby, UnderWater, Sushi
    }


    [SerializeField] private Image background;
    [SerializeField] private Image keyImage;
    [SerializeField] private GameObject InputGO;
    [SerializeField] private EState State;

    private Player_Lobby LobbyPlayer;
    private PlayerInteraction playerInteraction;
    private Object_DiveTrigger diveTrigger;
    private Vector3 screenPosition;
    private Slider slider;
    private bool isOn => playerInteraction.Interaction();
    private void Awake()
    {
        background.enabled = false;
        slider = GetComponentInChildren<Slider>();
        diveTrigger = FindObjectOfType<Object_DiveTrigger>();
        playerInteraction = FindObjectOfType<PlayerInteraction>();
        LobbyPlayer = FindObjectOfType<Player_Lobby>();
    }

    private void Update()
    {
        if (isOn)
        {
            screenPosition = Camera.main.WorldToScreenPoint(playerInteraction.Point);
            transform.position = screenPosition;
            keyImage.enabled = true;

            FillSlider(playerInteraction.PressKey && diveTrigger.isDiveTrigger);
        }
        else
        {
            keyImage.enabled = false;

        }
    }

    public bool FillSlider(bool pressKey)
    {
        if (pressKey)
        {
            if (slider.value < 1)
            {
                slider.value = Mathf.MoveTowards(slider.value, 1f, Time.deltaTime * 0.5f);
                return false;
            }
            else
            {
                slider.gameObject.SetActive(false);
                InputGO.SetActive(false);
                LobbyPlayer.Ready();
                return true;
            }
        }
        else
            slider.value = 0;
        return false;

    }

    public void OnBG(bool isOn)
    {
        background.enabled = isOn;
    }

}
