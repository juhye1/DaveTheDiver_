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
            //Debug.Log(dir);

            //dir = (dir < -130) ? dir += 130 : dir;
            //Debug.Log(dir);
            //dir = Mathf.Clamp(dir, -20, 20);

            if (player.MousePosition.x > 700)
            {
                //무조건 0~360값으로 바뀜
                //  -14도는 345도?
                //arrow.localRotation = Quaternion.Euler(0,0,dir);

                float right = Mathf.Clamp(dir, -20, 20);
                arrow.localEulerAngles = new Vector3(0, 0, right);
                //Debug.Log(arrow.localEulerAngles);
            }
            else
            {
                Vector3 left = Quaternion.Euler(0, 180, dir).eulerAngles;
                left.z = Mathf.Clamp(left.z, 160, 200);
                arrow.localEulerAngles = left;
/*                Vector3 angle = new Vector3(0, 0, dir);
                angle.z = (angle.z > 180) ? angle.z - 360 : angle.z;
                angle.z = Mathf.Clamp(angle.z, -20, 20);
                arrow.localRotation = Quaternion.Euler(angle);*/

                //Debug.Log(arrow.localRotation.z);

            }

        }
    }
}
