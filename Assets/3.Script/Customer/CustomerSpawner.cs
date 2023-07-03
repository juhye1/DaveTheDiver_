using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechBubble
{
    public Sprite Bubble;
    public Sprite Order;


}
    public class CustomerSpawner : MonoBehaviour
{

    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Customer customer;
    [SerializeField] private Sprite[] CustomerSprites;

    [SerializeField] private Sprite[] BubbleSprites;
    [SerializeField] private Sprite[] OrderSprites;

    private List<Sprite> OrderList;

    private List<Transform> goal;
    private Chair chair;
    private int num;
    private int rdn;
    private SpeechBubble bubble;

    public bool Sit { get { return customer.Sit; } private set { } }

    [SerializeField] protected GameObject[] TeaUI;

    private List<int> sprites;

    //목적지 정해야하고 생긴거 정해야하고 애니메이터까지?

    private void Awake()
    {
        chair = FindObjectOfType<Chair>();
        sprites = new List<int>();
        goal = new List<Transform>();
        




        for (int i = 0; i < CustomerSprites.Length; i++)
        {
            sprites.Add(i);
        }
    }
    private void Start()
    {
        SpawnCustomer();
    }


    private void SpawnCustomer()
    {
        goal = chair.EmptyChairs();
        for (int i = 0; i < 3; i++)
        {
            Gacha();

            Customer _customer = Instantiate(customer, spawnPoint.position, Quaternion.identity);
            _customer.transform.SetParent(transform);
            _customer.Init(CustomerSprites[num], goal[i], bubble);
            _customer.GetComponent<BaseCustomer>().Init(TeaUI);
            sprites.Remove(num);

        }
    }

    private void Gacha()
    {
        //의자 뽑기

        for (int j = 0; j < 10; j++)
        {
            //얼굴 뽑기
            rdn = Random.Range(0, CustomerSprites.Length);
            if (sprites.Contains(rdn))
            {
                num = rdn;
                break;
            }
        }
        //말풍선, 주문
        //0번이면 무조건 녹차, 1번이면 음식

        //음식 > 말풍선 순서가 맞는듯?
/*        rdn = Random.Range(0, BubbleSprites.Length);
        bubble = new SpeechBubble();
        bubble.Bubble = BubbleSprites[rdn];

        switch(rdn)
        {
            case 0:
                bubble.Order = OrderSprites[0];
                //녹차
                break;
            case 1:
                int num = Random.Range(1, OrderSprites.Length);
                bubble.Order = OrderSprites[num];
                //OrderList.Add(OrderSprites[num]);
                //음식
                break;

        }
*/
        bubble = new SpeechBubble();
        rdn = Random.Range(0, OrderSprites.Length);
        bubble.Order = OrderSprites[rdn];

        switch (rdn)
        {
            case 0:
                bubble.Bubble = BubbleSprites[0];
                //녹차
                break;
            default:
                bubble.Bubble = BubbleSprites[1];
                //OrderList.Add(OrderSprites[num]);
                //음식
                break;

        }
    }

    public List<Sprite> GetOrderList()
    {
        List<Sprite> orderList = OrderList;
        OrderList.Clear();
        return orderList;
    }

}
