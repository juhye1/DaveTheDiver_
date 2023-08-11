using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBubble : MonoBehaviour
{
    [SerializeField] private Transform player;
    private void Update()
    {
        transform.position = player.position;
    }
}
