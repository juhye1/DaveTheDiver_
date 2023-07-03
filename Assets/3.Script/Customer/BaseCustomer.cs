using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCustomer : MonoBehaviour
{
    protected BaseInteraction baseInteraction;
    public bool CanPerform { get; protected set; } = true;

    private GameObject[] TeaUI;
    protected bool isOn { get; set; } = false;
    private Spawner spawner;
    private Customer customer;

    private void Awake()
    {
        baseInteraction = GetComponent<BaseInteraction>();
        spawner = FindObjectOfType<Spawner>();
        customer = GetComponent<Customer>();
    }

    public void UIOn()
    {
        UIManager.Instance.SushiUI(!isOn, TeaUI);
        isOn = !isOn;
    }
    public void Tea()
    {
        switch (baseInteraction.InteractionType)
        {
            case BaseInteraction.EInteractionType.Enter:
                spawner.ResetTea();
                UIOn();
                break;
            case BaseInteraction.EInteractionType.Tick:
                spawner.SpawnTea();
                break;
            case BaseInteraction.EInteractionType.End:
                spawner.ResetTea();
                UIOn();
                break;

        }
    }

    public void Sushi()
    {
        bool check = SushiGameManager.Instance.DeliverSushi(customer.bubble.Order);
        if(check)
        {
            customer.Eat();
            //맞으면 데이브랑 얘 UI끄고,,,,,,,,,,머리위에 이모티콘,,,띄우고,,,,하트 나와야하고,,

        }
        //내가 들고 있는 음식이 본인 주문과 같으면 성공
        //아니면 무시
    }



    public void Init(GameObject[] gameObjects)
    {
        TeaUI = gameObjects;
    }
}
