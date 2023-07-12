using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : Singleton<CameraManager>
{
    private CinemachineVirtualCamera virtualCamera;
    private Player player;
    private float defaultFieldOfView = 80;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        virtualCamera.m_Lens.FieldOfView = defaultFieldOfView;
    }

    public bool ZoomIn()
    {
        float goal = 60;
        virtualCamera.m_Lens.FieldOfView = Mathf.Lerp(virtualCamera.m_Lens.FieldOfView, goal, Time.deltaTime*2);

        if (virtualCamera.m_Lens.FieldOfView - goal < 1)
            return true;
        else return false;

    }

    public bool ZoomZoomIn(Transform harpoon)
    {
        float goal = 40;
        virtualCamera.m_Lens.FieldOfView = Mathf.Lerp(virtualCamera.m_Lens.FieldOfView, goal, Time.deltaTime * 10);
        virtualCamera.m_Follow = harpoon;
        Debug.Log(virtualCamera.Follow.name);

        if (virtualCamera.m_Lens.FieldOfView - goal < 1)
        {
            virtualCamera.m_Follow = player.transform;
            return true;
        }
        else return false;
    }

    public bool ZoomOut()
    {
        float goal = defaultFieldOfView;
        virtualCamera.m_Lens.FieldOfView = Mathf.Lerp(virtualCamera.m_Lens.FieldOfView, goal, Time.deltaTime*10);
        if (goal - virtualCamera.m_Lens.FieldOfView < 1)
            return true;
        else return false;

    }
}
