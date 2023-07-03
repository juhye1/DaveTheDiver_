using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bancho_Cooking : MonoBehaviour
{
    //여기서 할 거
    //손님 주문 그림 찾기
    //손님이 앉으면 요리 시작하기
    //슬라이더 올리기
    //슬라이더 끝나면 요리 나오게 하기


    [SerializeField] private Slider banchoSlider;
    private Image image;
    private List<Sprite> OrderList;

    private void Awake()
    {
        image = banchoSlider.GetComponentInChildren<Image>();
        OrderList = new List<Sprite>();
    }

    public void Order(Sprite order)
    {
        //먼저 앉은애 우선?
        OrderList.Add(order);
        image.sprite = OrderList[0];
    }

    public void StartCooking()
    {
        banchoSlider.value = Mathf.MoveTowards(banchoSlider.value, 1, Time.deltaTime * 0.1f);

        if(banchoSlider.value.Equals(1))
        {
            ResetSlider();
        }
    }

    private void ResetSlider()
    {
        OrderList.Remove(OrderList[0]);
        if(!NullOrder())
        {
            image.sprite = OrderList[0];
        }
        
        banchoSlider.value = 0;
    }

    private bool NullOrder()
    {
        bool order = OrderList.Count.Equals(0) ? true : false;
        return order;
    }
    private void Update()
    {
        if(!NullOrder())
        {
            StartCooking();
        }
    }



}
