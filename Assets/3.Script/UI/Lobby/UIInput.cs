using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInput : MonoBehaviour
{


    private RectTransform[] transforms;
    [SerializeField] private RectTransform select;
    private Dictionary<Vector2, EDirection> direction = new Dictionary<Vector2, EDirection>();
    private int num;
    private void Awake()
    {
        num = 1;
        transforms = GetComponentsInChildren<RectTransform>();
        AddDirection();

    }
    public void Inventory(Vector2 dir)
    {
        EDirection edir = direction[dir];

        switch (edir)
        {
            case EDirection.Up:
                num -= 8;
                break;
            case EDirection.Down:
                num += 8;
                break;
            case EDirection.Right:
                num++;
                break;
            case EDirection.Left:
                num--;
                break;
        }

        num = Mathf.Clamp(num, 1, 32);
        select.anchoredPosition = transforms[num].anchoredPosition;
    }

    private void AddDirection()
    {
        direction.Add(Vector2.up, EDirection.Up);
        direction.Add(Vector2.down, EDirection.Down);
        direction.Add(Vector2.right, EDirection.Right);
        direction.Add(Vector2.left, EDirection.Left);
    }
}
