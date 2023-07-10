using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private Camera mainCamera;
    private RectTransform rectTransform;
    private Vector3 screenPosition;
    [SerializeField] private Transform dave;
    [SerializeField] private Transform point;
    [SerializeField] private RectTransform arrow;
    [SerializeField] private RectTransform dd;
    private Player_Underwater player;
    private Vector2 Direction => player.MousePosition;
    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        player = FindObjectOfType<Player_Underwater>();
        mainCamera = Camera.main;
        //rectTransform.pivot = dave.position;
    }

    // Update is called once per frame
    void Update()
    {
        screenPosition = mainCamera.WorldToScreenPoint(point.position);
        transform.position = screenPosition;
     
       if(player!=null)
        {
            Vector3 dirVec = player.MousePosition - (Vector2)transform.position;
            float ff = Mathf.Atan2(dirVec.y, dirVec.x) * Mathf.Rad2Deg;
            ff = Mathf.Clamp(ff, -23, 23);
            arrow.rotation = Quaternion.Euler(0, 0, ff);

        }
    }
}
