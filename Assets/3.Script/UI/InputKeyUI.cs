using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputKeyUI : MonoBehaviour
{
    private Image keyImage;
    private Player playerInput;
    private Vector3 screenPosition;
    private bool isOn => playerInput.Interaction();
    private void Awake()
    {
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


}
