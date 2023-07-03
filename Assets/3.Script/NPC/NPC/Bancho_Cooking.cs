using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Bancho_Cooking : MonoBehaviour
{
    //여기서 할 거
    //손님 주문 그림 찾기
    //손님이 앉으면 요리 시작하기
    //슬라이더 올리기
    //슬라이더 끝나면 요리 나오게 하기


    [SerializeField] private Slider banchoSlider;
    [SerializeField] private GameObject banchoUI;
    [SerializeField] private Sprite[] backgroundSprites;
    private GameObject clone;
    private Image backgroundImage;
    private Image image;
    private NPC_Bancho bancho;
    private List<Sprite> OrderList;
    private List<Sprite> CookedList;
    private int first = 0;
    private bool cooked = false;

    private void Awake()
    {
        image = banchoSlider.GetComponentInChildren<Image>();
        backgroundImage = banchoUI.GetComponent<Image>();
        bancho = GetComponent<NPC_Bancho>();
        OrderList = new List<Sprite>();
        CookedList = new List<Sprite>();
        backgroundImage.sprite = backgroundSprites[0];

        banchoUI.SetActive(false);
    }

    public void Order(Sprite order)
    {
        //먼저 앉은애 우선?
        OrderList.Add(order);
        image.sprite = OrderList[first];
    }

    private void StartCooking()
    {
        banchoSlider.value = Mathf.MoveTowards(banchoSlider.value, 1, Time.deltaTime * 0.3f);

       if(banchoSlider.value.Equals(1))
        {
            StartCoroutine(ResetSlider());
            cooked = !cooked;
        }
    }

    private bool Cooked()
    {
        return cooked;
    }

    private IEnumerator ResetSlider()
    {
        backgroundImage.sprite = backgroundSprites[1];
        banchoUI.transform.DOPunchScale(Vector3.one * 0.5f, 0.3f, 1, 0.5f);
        CookedList.Add(OrderList[first]);
        OrderList.Remove(OrderList[first]);
        yield return new WaitForSeconds(0.5f);

        MakeClone();

        if (!NullOrder())
        {
            image.sprite = OrderList[first];
        }

        banchoUI.transform.DOLocalMoveY(10, 1);

        banchoSlider.value = 0;
        backgroundImage.sprite = backgroundSprites[0];
        cooked = !cooked;
    }

    private void MakeClone()
    {
        clone = Instantiate(banchoUI, banchoUI.transform.parent);
        clone.transform.position = banchoUI.transform.position;
    }
    private bool NullOrder()
    {
        bool order = OrderList.Count.Equals(0) ? true : false;
        banchoUI.SetActive(!order);
        bancho.StartCook(!order);
        return order;
    }
    private void Update()
    {
        if(!NullOrder())
        {
            if (!Cooked())
                StartCooking();
            else ResetSlider();
        }
    }

    public Sprite CookedSushi()
    {
        Sprite sushi;
        if (!CookedList.Count.Equals(0))
        {
            Destroy(clone);
            sushi = CookedList[first];
            CookedList.Remove(sushi);
            return sushi;
        }
        else return null;
    }



}
