using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BanchoUI : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private GameObject banchoUI;
    [SerializeField] private Slider slider;
    [SerializeField] private Image backgroundImage;
    [SerializeField] private Image orderImage;
    [Header("Sprites")]
    [SerializeField] private Sprite[] backgroundSprites;

    private Bancho_Cooking bancho;
    private List<GameObject> clones;

    private bool cooked = false;

    private void Awake()
    {
        clones = new List<GameObject>();
        bancho = FindObjectOfType<Bancho_Cooking>();
        banchoUI.SetActive(false);
        slider.value = 0;
    }

    private void Update()
    {
        if(HaveOrder())
        {
            if(!cooked)
            StartCooking();

        }
    }



    public void GetOrder(Sprite order)
    {
        backgroundImage.sprite = backgroundSprites[0];
        orderImage.sprite = order;
    }


    private void StartCooking()
    {
        slider.value = Mathf.MoveTowards(slider.value, 1, Time.deltaTime * 0.3f);

        if (slider.value.Equals(1))
        {
            StartCoroutine(ResetSlider());
            cooked = !cooked;
        }
    }

    private IEnumerator ResetSlider()
    {
        backgroundImage.sprite = backgroundSprites[1];
        banchoUI.transform.DOPunchScale(Vector3.one * 0.5f, 0.3f, 1, 0.5f);
        yield return new WaitForSeconds(0.5f);

        GameObject clone = Instantiate(banchoUI, transform);
        clones.Add(clone);

        slider.value = 0;
        if(clones.Count.Equals(2))
        {
            clone.transform.DOLocalMoveY(0, 0.5f);
            banchoUI.transform.DOLocalMoveY(60, 0.5f);
        }
        else
        {
            banchoUI.transform.DOLocalMoveY(0, 0.5f);
        }

        bancho.EndCooking();
        cooked = !cooked;
    }

    public void DestroyClone()
    {
        Destroy(clones[0]);
        clones.Remove(clones[0]);

        switch (clones.Count)
        {
            case 0:
                banchoUI.transform.DOLocalMoveY(-60, 0.5f);
                break;
            case 1:
                banchoUI.transform.DOLocalMoveY(0, 0.5f);
                clones[0].transform.DOLocalMoveY(-60, 0.5f);
                break;
        
        }
    }

    public void UIOn(bool isOn)
    {
        banchoUI.SetActive(isOn);
    }

    private bool HaveOrder()
    {
        return banchoUI.activeSelf;
    }

}
