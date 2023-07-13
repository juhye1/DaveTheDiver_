using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    private Boid boid;
    [SerializeField] private FishInformation fishInfo;
    
    private void Awake()
    {
        boid = GetComponent<Boid>();
    }

    public void Fishing(Transform harpoon)
    {
        //군집 알고리즘 떼기
        BoidsManager.Instance.RemoveBoid(boid);
        //인벤 토리 저장
        BaseInformation info = new BaseInformation(fishInfo, BaseInformation.EType.Fish, fishInfo.Name);
        InventoryManager.Instance.Save(info);

        transform.SetParent(harpoon);
        transform.localPosition = Vector3.zero;
    }

}

