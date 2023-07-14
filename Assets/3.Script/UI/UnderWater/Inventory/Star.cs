using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Star : MonoBehaviour
{
    private Image[] stars;

    [SerializeField] private Sprite OnStar;
    [SerializeField] private Sprite OffStar;

    private void Awake()
    {
        stars = GetComponentsInChildren<Image>();
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

    private void ResetStar()
    {
        for (int i = 0; i < stars.Length; i++)
        {
            stars[i].enabled = true;
            stars[i].sprite = OffStar;
        }
    }


}
