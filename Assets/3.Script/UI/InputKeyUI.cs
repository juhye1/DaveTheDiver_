using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputKeyUI : MonoBehaviour
{
    private Image keyImage;
    private Player playerInput;
    private Vector3 screenPosition;
    private Slider slider;
    private bool isOn => playerInput.Interaction();
    private void Awake()
    {
        slider = GetComponentInChildren<Slider>();
        keyImage = GetComponent<Image>();
        playerInput = FindObjectOfType<Player>();
    }

    private void Update()
    {
        if (isOn)
        {
            screenPosition = Camera.main.WorldToScreenPoint(playerInput.Point);
            transform.position = screenPosition;
            keyImage.enabled = true;
        }
        else
            keyImage.enabled = false;
    }

    public bool dd()
    {
        if (slider.value < 1)
        {
            slider.value = Mathf.MoveTowards(slider.value, 1f, Time.deltaTime * 0.5f);
            return false;
        }
        else return true;
    }


}
