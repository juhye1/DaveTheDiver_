using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteColorController : MonoBehaviour
{
    private SpriteRenderer[] spriteRenderers;
    [SerializeField] private Color Eveningcolor;

    private void Awake()
    {
        spriteRenderers = GetComponentsInChildren<SpriteRenderer>();


    }

    public void SetEveningColor()
    {
        if (spriteRenderers == null) return;
        foreach (SpriteRenderer rend in spriteRenderers)
        {
            rend.color = Eveningcolor;
        }
    }
}
