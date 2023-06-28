using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputKeyUI : MonoBehaviour
{
    private Image keyImage;
    private PlayerInteraction playerInteraction;
    private Vector3 screenPosition;
    private Slider slider;
    private bool isOn => playerInteraction.Interaction();
    private void Awake()
    {
        slider = GetComponentInChildren<Slider>();
        keyImage = GetComponent<Image>();
        playerInteraction = FindObjectOfType<PlayerInteraction>();
    }

    private void Update()
    {
        if (isOn)
        {
            screenPosition = Camera.main.WorldToScreenPoint(playerInteraction.Point);
            transform.position = screenPosition;
            keyImage.enabled = true;
        }
        else
            keyImage.enabled = false;
    }

    public bool FillSlider()
    {
        if (slider.value < 1)
        {
            slider.value = Mathf.MoveTowards(slider.value, 1f, Time.deltaTime * 0.5f);
            return false;
        }
        else
        {
            slider.gameObject.SetActive(false);
            return true;
        }
    }


}
