using System.Collections;
using System.Collections.Generic;
using UnityEngine.Experimental.U2D.Animation;
using UnityEngine;
using UnityEngine.AddressableAssets;
using System.IO;


public class SpeechBubble
{
    public Sprite Bubble;
    public Sprite Order;
}
public class CustomerSpawner : MonoBehaviour
{
    public AssetReference dd;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Customer customer;

    [SerializeField] private Sprite[] BubbleSprites;
    private List<Sprite> OrderSprites;

    [SerializeField] private GameObject[] TeaUI;
    [SerializeField] private SpriteLibraryAsset[] spriteLibraryAsset;

    private Dictionary<int, SpriteLibraryAsset> spriteLibraryDictionary;

    private CustomerSpawnFromBundle customerSpawnFromBundle;
    private List<Sprite> OrderList;
    private List<Chairs> goal;
    private List<int> closet;
    private List<Vector3> spawnPoints;

    private MiniMenuUI miniMenuUI;
    private Sprite saveSprite;

    private Chair chair;
    private SpeechBubble bubble;
    private SpeechBubble spareBubble;
    private Customer.EOrderType orderType;
    private int num;
    private int rdn;
    private string bundleName;
    private string assetName;

    //목적지 정해야하고 생긴거 정해야하고 애니메이터까지?

    private void Awake()
    {
        bundleName = "customer";
        assetName = "Customer";

        customerSpawnFromBundle = GetComponent<CustomerSpawnFromBundle>();
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
        //StartCoroutine(Spawn());
        SpawnCustomer();
    }


    private void SpawnCustomer()
    {
        AddSpawnPoints();
        goal = chair.EmptyChairs();

        for (int i = 0; i < 3; i++)
        {
            orderType = new Customer.EOrderType();
            Gacha();

            int index = i;
            int numIndex = num;

            var go = dd.InstantiateAsync();
            go.Completed += (op) =>
            {
                Customer _customer = go.Result.GetComponent<Customer>();

                if (_customer == null)
                {
                    Debug.Log("널이에요");
                }

                _customer.transform.SetParent(transform);
                _customer.transform.position = spawnPoints[index];
                Debug.Log(numIndex);
                _customer.Init(goal[index], bubble, spareBubble, orderType, spawnPoint, spriteLibraryDictionary[numIndex], numIndex);
                _customer.SetKey(saveSprite);
                _customer.GetComponent<BaseCustomer>().Init(TeaUI);
                spriteLibraryDictionary.Remove(numIndex);
            _customer.SwitchState(Customer.EState.MoveToChair);

            };

            // Customer _customer = go.Result.GetComponent<Customer>();

            //Customer _customer = Instantiate(customer, spawnpoints[i], Quaternion.identity);
            //Customer _customer = customerSpawnFromBundle.SpawnCustomer();
            /*if (_customer == null)
            {
                Debug.Log("널이에요");
            }

            _customer.transform.SetParent(transform);
            _customer.Init(goal[i], bubble, spareBubble, orderType, spawnPoint, spriteLibraryDictionary[num], num);
            _customer.SetKey(saveSprite);
            _customer.GetComponent<BaseCustomer>().Init(TeaUI);
            spriteLibraryDictionary.Remove(num);*/

        }
    }

    public void UpdateCustomer(Customer _customer)
    {
        //빈 의자로 바꾸기
        chair.UpdateChair(_customer.chair);
        orderType = new Customer.EOrderType();
        //새로운 의자 찾기
        Chairs _goal = chair.EmptyOneChair();
        //새로운 주문
        Gacha();

        //옷 반납
        spriteLibraryDictionary.Add(_customer.clothes, spriteLibraryAsset[_customer.clothes]);
        //새 옷 입기
        _customer.Init(_goal, bubble, spareBubble, orderType, spawnPoint, spriteLibraryAsset[num], num);
        //입고 있는 옷 빼기
        spriteLibraryDictionary.Remove(num);
        //새 출발
        _customer.SwitchState(Customer.EState.MoveToChair);

    }

    private void AddSpawnPoints()
    {
        spawnPoints = new List<Vector3>();
        for (int i = 0; i < 3; i++)
        {
            Vector3 pos = new Vector3(spawnPoint.position.x - 0.2f * i, spawnPoint.position.y, spawnPoint.position.x);
            spawnPoints.Add(pos);
        }
    }


    private void Gacha()
    {
        OrderSprites = miniMenuUI.MenuSushiSprite();
        //의자 뽑기

        for (int j = 0; j < 10; j++)
        {
            //옷 뽑기
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
        saveSprite = OrderSprites[rdn];

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

    private IEnumerator Spawn()
    {
        AddSpawnPoints();
        goal = chair.EmptyChairs();

        for (int i = 0; i < 3; i++)
        {
            orderType = new Customer.EOrderType();
            Gacha();

            /*       AssetBundle localAssetBundle =
                   AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath, bundleName));

       *//*            yield return asyncBundleRequest;

                   AssetBundle localAssetBundle = asyncBundleRequest.assetBundle;*//*

                   if (localAssetBundle == null)
                   {
                       Debug.LogError("번들 로드 실패");
                       yield break;
                   }


                   localAssetBundle.LoadAssetWithSubAssets<GameObject>(assetName);
                   //AssetBundleRequest assetRequest = localAssetBundle.LoadAssetAsync<GameObject>(assetName);
                   AssetBundleRequest assetRequest = localAssetBundle.LoadAssetWithSubAssetsAsync(assetName);
                   yield return assetRequest;

                   var prefab = assetRequest.asset as GameObject;

                   GameObject customerGo = Instantiate(prefab, spawnPoints[i], Quaternion.identity);
                   yield return new WaitForSeconds(0.01f);
                   localAssetBundle.Unload(true);


                   Customer _customer = customerGo.GetComponent<Customer>();
       */
            var go = dd.InstantiateAsync();
            Customer _customer = go.Result.GetComponent<Customer>();
            
            if (_customer == null)
            {
                Debug.Log("널이에요");
            }

            _customer.transform.SetParent(transform);
            _customer.Init(goal[i], bubble, spareBubble, orderType, spawnPoint, spriteLibraryDictionary[num], num);
            _customer.SetKey(saveSprite);
            _customer.GetComponent<BaseCustomer>().Init(TeaUI);
            spriteLibraryDictionary.Remove(num);

            _customer.gameObject.SetActive(true);

            _customer.SwitchState(Customer.EState.MoveToChair);


            yield return null;
        }
    }

}
