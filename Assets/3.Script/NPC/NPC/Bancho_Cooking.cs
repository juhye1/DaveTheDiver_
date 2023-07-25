using System.Collections;
using System.Collections.Generic;
using System;
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


    //주문이랑 그림만 넣고
    //슬라이더 올라가는거랑 그런거는 UI가 알아서 하도록?

    private BanchoUI banchoUI;

    private NPC_Bancho bancho;
    private List<Sprite> OrderList;
    private List<Sprite> CookedList;


    private void Awake()
    {
        banchoUI = FindObjectOfType<BanchoUI>();
        bancho = GetComponent<NPC_Bancho>();
        OrderList = new List<Sprite>();
        CookedList = new List<Sprite>();
    }

    public void Order(Sprite order)
    {
        //먼저 앉은애 우선?
        OrderList.Add(order);
        banchoUI.GetOrder(OrderList[0]);
    }


    public void EndCooking()
    {
        CookedList.Add(OrderList[0]);
        OrderList.Remove(OrderList[0]);

        if (!OrderList.Count.Equals(0))
        banchoUI.GetOrder(OrderList[0]);
    }


    private void OrderCheck()
    {
        bool order = OrderList.Count.Equals(0) ? true : false;
        bancho.StartCook(!order);
        banchoUI.UIOn(!order);
    }
    private void Update()
    {
        OrderCheck();
    }

    public Sprite CookedSushi()
    {
        //요리 가져가기
        Sprite sushi;
        if (!CookedList.Count.Equals(0))
        {
            Debug.Log("a");
            sushi = CookedList[0];
            banchoUI.DestroyClone();
            CookedList.Remove(sushi);
            return sushi;
        }
        else
            return null;

    }

}
