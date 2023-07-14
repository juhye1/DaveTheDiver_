using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    private Boid boid;
    [SerializeField] private Information<FishInformation> fishInfo;
    
    private void Awake()
    {
        boid = GetComponent<Boid>();
    }

    public void Fishing(Transform harpoon)
    {
        //군집 알고리즘 떼기
        BoidsManager.Instance.RemoveBoid(boid);
        //인벤 토리 저장
        InventoryManager.Instance.Save<FishInformation>(fishInfo);

        transform.SetParent(harpoon);
        transform.localPosition = Vector3.zero;
    }

}

