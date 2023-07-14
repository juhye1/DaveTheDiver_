using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseUI : MonoBehaviour
{
    [SerializeField] GameObject pauseUI;

    private void Awake()
    {
        pauseUI.SetActive(false);
    }
    //여기다가 하나하나 저장
    public void UIOn(bool isOn)
    {
        pauseUI.SetActive(isOn);
    }
}
