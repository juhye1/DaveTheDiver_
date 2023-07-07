using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Underwater : PlayerInteraction
{
    private Vector2 move;

    private void Start()
    {
        
    }
    private void FixedUpdate()
    {
        Move();
    }
}
