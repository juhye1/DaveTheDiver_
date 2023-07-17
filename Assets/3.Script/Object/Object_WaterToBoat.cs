using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_WaterToBoat : BaseObject
{
    private BoatUI boatUI;



    public enum EState
    {
        Off, On
    }

    private EState state = EState.Off;
    private BoatUI.EState boatState => boatUI.State;


    private void Start()
    {
        boatUI = FindObjectOfType<BoatUI>();
        CanPerform = !CanPerform;
    }

    public override void Interaction()
    {
        Debug.Log("ff");
        //isOn = !isOn;

        switch (boatUI.State)
        {
            case BoatUI.EState.GotoBoat:
                Debug.Log("ff");
                GameManager.Instance.LoadScene(GameManager.EScene.Lobby);
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
