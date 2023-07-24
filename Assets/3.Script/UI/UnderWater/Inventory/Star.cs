using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Star : MonoBehaviour
{
    private Image[] stars;
    private Color alphaColor;
    private Color defaultColor;

    [SerializeField] private Sprite OnStar;
    [SerializeField] private Sprite OffStar;

    private void Awake()
    {
        stars = GetComponentsInChildren<Image>();
        alphaColor = stars[0].color;
        defaultColor = stars[0].color;
        alphaColor.a = 0.5f;
    }

    public void StarOn(int star)
    {
        if(star == 0)
        {
            foreach(Image img in stars)
            {
                img.enabled = false;
            }
            return;
        }
        
        ResetStar();
        for (int i = 0; i < star; i++)
        {
            stars[i].sprite = OnStar;
        }
    }

    public void StarAlpha(int star)
    {
        ResetAlphaStar();
        if (star == 0) return;

        Debug.Log(star);
        star = Mathf.Clamp(star, 0, 3);
        for (int i = 0; i < star; i++)
        {
            stars[i].color = defaultColor;
        }

    }

    private void ResetAlphaStar()
    {
        foreach (Image img in stars)
        {
            img.color = alphaColor;
        }
    }


    private void ResetStar()
    {
        for (int i = 0; i < stars.Length; i++)
        {
            stars[i].enabled = true;
            stars[i].sprite = OffStar;
        }
    }


}
