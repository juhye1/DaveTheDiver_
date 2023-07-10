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
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player_Underwater>();
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        screenPosition = mainCamera.WorldToScreenPoint(point.position);
        transform.position = screenPosition;
     
       if(player!=null)
        {
            Vector3 dirVec = player.MousePosition - (Vector2)transform.position;
            float dir = Mathf.Atan2(dirVec.y, dirVec.x) * Mathf.Rad2Deg;
            dir = Mathf.Clamp(dir, -23, 23);
            arrow.rotation = Quaternion.Euler(0, 0, dir);

        }
    }
}
