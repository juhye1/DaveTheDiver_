using System.Collections;
using System.Collections.Generic;
using UnityEngine.Experimental.U2D.Animation;
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

    [SerializeField] private Sprite[] BubbleSprites;
    private List<Sprite> OrderSprites;

    [SerializeField] private GameObject[] TeaUI;
    [SerializeField] private SpriteLibraryAsset[] spriteLibraryAsset;

    private Dictionary<int, SpriteLibraryAsset> spriteLibraryDictionary;


    private List<Sprite> OrderList;
    private List<Chairs> goal;
    private List<int> closet;

    private MiniMenuUI miniMenuUI;

    private Chair chair;
    private SpeechBubble bubble;
    private SpeechBubble spareBubble;
    private Customer.EOrderType orderType;
    private int num;
    private int rdn;

    //목적지 정해야하고 생긴거 정해야하고 애니메이터까지?

    private void Awake()
    {
        spriteLibraryDictionary = new Dictionary<int, SpriteLibraryAsset>();
        miniMenuUI = FindObjectOfType<MiniMenuUI>();
        chair = FindObjectOfType<Chair>();
        closet = new List<int>();
        goal = new List<Chairs>();
        for (int i = 0; i < spriteLibraryAsset.Length; i++)
        {
            spriteLibraryDictionary.Add(i, spriteLibraryAsset[i]);
            closet.Add(i);
        }
    }
    private void Start()
    {
        SpawnCustomer();
    }


    private void SpawnCustomer()
    {
        List<Vector3> spawnpoints = SpawnPoints();
        goal = chair.EmptyChairs();

        for (int i = 0; i < 3; i++)
        {
            orderType = new Customer.EOrderType();
            Gacha();

            Customer _customer = Instantiate(customer, spawnpoints[i], Quaternion.identity);
            _customer.transform.SetParent(transform);
            _customer.Init(goal[i], bubble, spareBubble, orderType, spawnPoint, spriteLibraryDictionary[num], num);
            _customer.GetComponent<BaseCustomer>().Init(TeaUI);
            spriteLibraryDictionary.Remove(num);

        }
    }

    public void UpdateCustomer(Customer _customer)
    {
        chair.UpdateChair(_customer.chair);
        orderType = new Customer.EOrderType();
        Chairs _goal = chair.EmptyOneChair();
        Gacha();

        spriteLibraryDictionary.Add(_customer.clothes, spriteLibraryAsset[_customer.clothes]);
        _customer.Init(_goal, bubble, spareBubble, orderType, spawnPoint, spriteLibraryAsset[num], num);
        spriteLibraryDictionary.Remove(num);
        _customer.SwitchState(Customer.EState.MoveToChair);

    }

    private List<Vector3> SpawnPoints()
    {
        List<Vector3> spawnPoints = new List<Vector3>();
        for (int i = 0; i < 3; i++)
        {
            Vector3 pos = new Vector3(spawnPoint.position.x - 0.2f * i, spawnPoint.position.y, spawnPoint.position.x);
            spawnPoints.Add(pos);
        }

        return spawnPoints;
    }


    private void Gacha()
    {
        OrderSprites = miniMenuUI.MenuSushiSprite();
        //의자 뽑기

        for (int j = 0; j < 10; j++)
        {
            //얼굴 뽑기
            rdn = Random.Range(0, spriteLibraryAsset.Length);
            if (spriteLibraryDictionary.ContainsKey(rdn))
            {
                num = rdn;
                break;
            }
        }
        //말풍선, 주문
        //0번이면 무조건 녹차, 1번이면 음식
        bubble = new SpeechBubble();
        rdn = Random.Range(0, OrderSprites.Count);
        bubble.Order = OrderSprites[rdn];

        switch (rdn)
        {
            case 0:
                bubble.Bubble = BubbleSprites[0];
                orderType = Customer.EOrderType.Tea;
                //녹차
                break;
            default:
                bubble.Bubble = BubbleSprites[1];
                orderType = Customer.EOrderType.Sushi;
                //OrderList.Add(OrderSprites[num]);
                //음식
                break;

        }
        spareBubble = new SpeechBubble();
        spareBubble.Bubble = BubbleSprites[1];
        spareBubble.Order = OrderSprites[Random.Range(1, OrderSprites.Count)];
    }

    public List<Sprite> GetOrderList()
    {
        List<Sprite> _orderList = OrderList;
        OrderList.Clear();
        return _orderList;
    }

}
