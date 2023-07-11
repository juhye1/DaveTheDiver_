using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private Transform dave;
    [SerializeField] private Transform point;
    [SerializeField] private RectTransform arrow;

    private Player_Underwater player;
    private Camera mainCamera;
    private Vector3 screenPosition;
    private float y = 180;

    private Vector2 LeftVector;
    private Vector2 RightVector;
    void Start()
    {
        player = FindObjectOfType<Player_Underwater>();
        mainCamera = Camera.main;
        LeftVector = new Vector2(0, 180);
        RightVector = new Vector2(0, 0);
    }

    void Update()
    {
        screenPosition = mainCamera.WorldToScreenPoint(point.position);
        transform.position = screenPosition;
     
       if(player!=null)
        {
            Vector3 dirVec = player.MousePosition - (Vector2)transform.position;
            float dir = Mathf.Atan2(dirVec.y, dirVec.x) * Mathf.Rad2Deg;
            dir = Mathf.Clamp(dir, -20, 20);

            if (player.MousePosition.x < 700)
            {
                transform.eulerAngles = LeftVector;
                arrow.localRotation = Quaternion.Euler(0, y, dir);
            }
            else
            {
                transform.eulerAngles = RightVector;
                arrow.localRotation = Quaternion.Euler(0, 0, dir);

            }

        }
    }
}
