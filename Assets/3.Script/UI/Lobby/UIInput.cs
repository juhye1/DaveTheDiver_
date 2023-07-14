using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class UIInput : MonoBehaviour
{
    protected RectTransform[] transforms;
    [SerializeField] protected RectTransform select;
    protected Dictionary<Vector2, EDirection> direction = new Dictionary<Vector2, EDirection>();

    private void Awake()
    {
        AddDirection();

    }
    public abstract void Inventory(Vector2 dir);

    private void AddDirection()
    {
        direction.Add(Vector2.up, EDirection.Up);
        direction.Add(Vector2.down, EDirection.Down);
        direction.Add(Vector2.right, EDirection.Right);
        direction.Add(Vector2.left, EDirection.Left);
    }
}
