using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Object_BoatTrigger : BaseObject
{
    private SpriteRenderer spriteRenderer;
    private Transform spriteTransform;
    private Color color;
    private Color defaultColor;

    private void Start()
    {
        spriteTransform = GetComponent<Transform>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        defaultColor = spriteRenderer.color;
        color = spriteRenderer.color;
        color.a = 1;

    }
    public override void Interaction()
    {
        if (inputKeyUI == null)
        {
            inputKeyUI = FindObjectOfType<InputKeyUI>();
        }
        if (inputKeyUI.FillSlider())
        {
            player.LoadScene(ELoadScene.Sushi);
            CanPerform = !CanPerform;
        }
    }

    private void Update()
    {
        UIOn(on);
    }

    private void UIOn(bool on)
    {
        if (on)
        {
            spriteRenderer.color = color;
            spriteTransform.localScale = Vector2.one * 1.2f;
        }
        else
        {
            spriteRenderer.color = defaultColor;
            spriteTransform.localScale = Vector2.one;

        }
    }
}
