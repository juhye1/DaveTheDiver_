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
        BoidsManager.Instance.RemoveBoid(boid);
        InventoryManager.Instance.SaveFish(fishInfo);
        transform.SetParent(harpoon);
        transform.localPosition = Vector3.zero;
    }

}

