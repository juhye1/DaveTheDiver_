using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using DG.Tweening;

public class IntroSceneUI : UIInput
{
    [SerializeField] private Image fadeImage;
    [SerializeField] private TextMeshProUGUI start;
    [SerializeField] private TextMeshProUGUI exit;
    private Color defaultColor;
    private Color alphaColor;

    public override void MoveUI(Vector2 dir)
    {
        Debug.Log("FF");  
        EDirection edir = direction[dir];

        switch (edir)
        {
            case EDirection.Up:
                SetAlpha(start, defaultColor);
                SetAlpha(exit, alphaColor);
                num -= 1;
                break;
            case EDirection.Down:
                SetAlpha(start, alphaColor);
                SetAlpha(exit, defaultColor);
                num += 1;
                break;
        }

        num = Mathf.Clamp(num, 0, 2);
    }

    public override void Space()
    {
        switch (num)
        {

            case 1:
                Application.Quit();
                break;
            case 0:
                GameManager.Instance.LoadScene(GameManager.EScene.SushiToLobby);
                break;

        
        }
        
    }


    private void Start()
    {
        SoundManager.Instance.PlayBGM(EBGM.Title);
        fadeImage.enabled = true;
        defaultColor = start.color;
        alphaColor = defaultColor;
        alphaColor.a = 0.6f;
        num = 0;
        fadeImage.DOFade(0, 1);
        UIInputManager.Instance.SetInputUI(this, UIInputManager.EState.OnUI);
    }

    private void SetAlpha(TextMeshProUGUI tmp, Color color)
    {
        tmp.color = color;

    }

}
