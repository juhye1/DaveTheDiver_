using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    private Boid boid;
    private FishAnimator animator;
    [SerializeField] private ItemInformation fishInfo;
    
    private void Awake()
    {
        animator = GetComponent<FishAnimator>();
        boid = GetComponent<Boid>();
    }

    public void Fishing(Transform harpoon)
    {
        //군집 알고리즘 떼기
        fishInfo.Raiting = 2;
        BoidsManager.Instance.RemoveBoid(boid);
        //인벤 토리 저장
        InventoryManager.Instance.SaveItem(fishInfo);

        transform.SetParent(harpoon);
        transform.localPosition = Vector3.zero;
    }

    public void FishingDagger()
    {
        fishInfo.Raiting = 1;
        BoidsManager.Instance.RemoveBoid(boid);
        InventoryManager.Instance.SaveItem(fishInfo);
        animator.SetAnimation(FishAnimator.EFishState.die);
        Destroy(gameObject);
        //파티클도 나중에
        //죽ㅇㅓ
    }

}

