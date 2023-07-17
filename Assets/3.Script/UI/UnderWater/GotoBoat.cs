using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GotoBoat : MonoBehaviour
{
    private BoxCollider2D boxCollider;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Debug.Log("dd");
            UIManager.Instance.BoatUIOn();
            //UI ¶ç¿ì±â
            boxCollider.enabled = false;
        }
    }
}
