using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class CustomerSpawner : MonoBehaviour
{

    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Customer customer;
    [SerializeField] private Sprite[] CustomerSprites;
    private List<Transform> goal;
    private Chair chair;
    private int num;

    [SerializeField] protected GameObject[] TeaUI;

    private List<int> sprites;

    //목적지 정해야하고 생긴거 정해야하고 애니메이터까지?

    private void Awake()
    {
        chair = FindObjectOfType<Chair>();
        sprites = new List<int>();
        goal = new List<Transform>();
        goal = chair.SeatChair();


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
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                int rdn = Random.Range(0, CustomerSprites.Length);
                if (sprites.Contains(rdn))
                {
                    num = rdn;
                    break;
                }
            }

            Customer _customer = Instantiate(customer, spawnPoint.position, Quaternion.identity);
            _customer.transform.SetParent(transform);
            _customer.Init(CustomerSprites[num], goal[i]);
            _customer.GetComponent<BaseCustomer>().Init(TeaUI);
            sprites.Remove(num);

        }
    }
}
