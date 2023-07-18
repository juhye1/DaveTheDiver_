using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_WaterToBoat : BaseObject
{
    private BoatUI boatUI;
    [SerializeField] private Transform Point;
    [SerializeField] private Transform newPoint;
    private Vector3 point;
    private Vector3 newpoint;

    private void Start()
    {
        boatUI = FindObjectOfType<BoatUI>();
        point = Point.position;
        newpoint = newPoint.position;
        CanPerform = !CanPerform;
    }

    public void MoveCursor(BoatUI.EState state)
    {
        switch (state)
        {
            case BoatUI.EState.GotoBoat:
                Point.position = point;
                break;
            case BoatUI.EState.Cancel:
                Point.position = newpoint;
                break;
        }
    }

    public override void Interaction()
    {
        //isOn = !isOn;

        switch (boatUI.State)
        {
            case BoatUI.EState.GotoBoat:
                GameManager.Instance.LoadScene(GameManager.EScene.UnderWaterToLobby);
                break;
            case BoatUI.EState.Cancel:
                Debug.Log("UI²¨");
                break;
        }

    }

    private void Update()
    {
        if(on)
        {
            UIManager.Instance.BoatUIOn();
        }
    }


}
