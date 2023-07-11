using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Arms : MonoBehaviour
{
    private Player_Underwater player;
    [SerializeField] private Transform arrow;
    [SerializeField] private Transform arm;

    private void Awake()
    {
        player = GetComponentInParent<Player_Underwater>();
        arm.gameObject.SetActive(false);
    }
    public void MoveArms()
    {
        arm.gameObject.SetActive(true);
        if (player.MousePosition.x > 700)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, arrow.localEulerAngles.z);

        }
        else
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, arrow.localEulerAngles.z);
            arm.localRotation = Quaternion.Euler(180, 0, 0);
            //Debug.Log(arrow.localEulerAngles.z);
            //stransform.rotation = Quaternion.Euler(0, 0, arrow.localEulerAngles.z);
        }
    }

    public void OffArms()
    {
        arm.gameObject.SetActive(false);

    }
}
