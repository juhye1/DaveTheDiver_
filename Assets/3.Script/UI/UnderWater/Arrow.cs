using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private Transform point;
    [SerializeField] private Transform daveArm;
    [SerializeField] private RectTransform arrow;
    [SerializeField] private RectTransform gauge;

    private Player_Underwater player;
    private Camera mainCamera;
    private Vector2 screenPosition;
    private Vector2 playerScreenPosition;
    void Start()
    {
        player = FindObjectOfType<Player_Underwater>();
        mainCamera = Camera.main;
    }

    void Update()
    {
        screenPosition = mainCamera.WorldToScreenPoint(point.position);
        transform.position = screenPosition;
        transform.rotation = point.rotation;
     
       if(player != null)
        {
            playerScreenPosition = mainCamera.WorldToScreenPoint(daveArm.position);
            Vector2 offset = player.MousePosition - playerScreenPosition;
            float dir = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
            dir = Mathf.Clamp(dir, -20, 20);

            if (player.MousePosition.x > 700)
            {
                arrow.localRotation = Quaternion.Euler(0, 0, dir);
            }
            else
            {
                arrow.localRotation = Quaternion.Euler(0, 180, dir);
            }

        }
    }
}
