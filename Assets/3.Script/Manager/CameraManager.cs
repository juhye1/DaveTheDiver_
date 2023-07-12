using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : Singleton<CameraManager>
{
    private CinemachineVirtualCamera virtualCamera;
    private float defaultFieldOfView = 70;

    private void Start()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        virtualCamera.m_Lens.FieldOfView = defaultFieldOfView;
    }

    public bool ZoomIn()
    {
        float goal = 50;
        virtualCamera.m_Lens.FieldOfView = Mathf.Lerp(virtualCamera.m_Lens.FieldOfView, goal, Time.deltaTime*2);

        if (virtualCamera.m_Lens.FieldOfView - goal < 1)
            return true;
        else return false;

    }

    public bool ZoomZoomIn()
    {
        float goal = 30;
        virtualCamera.m_Lens.FieldOfView = Mathf.Lerp(virtualCamera.m_Lens.FieldOfView, goal, Time.deltaTime * 10);

        if (virtualCamera.m_Lens.FieldOfView - goal < 1)
            return true;
        else return false;
    }

    public bool ZoomOut()
    {
        float goal = 70;
        virtualCamera.m_Lens.FieldOfView = Mathf.Lerp(virtualCamera.m_Lens.FieldOfView, goal, Time.deltaTime*10);
        if (goal - virtualCamera.m_Lens.FieldOfView < 1)
            return true;
        else return false;

    }
}
