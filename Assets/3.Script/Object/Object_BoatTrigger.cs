using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Object_BoatTrigger : BaseObject
{
    public enum EState
    {
        Off, On
    }

    [SerializeField] private Transform Point;
    [SerializeField] private Transform newPoint;

    private Vector3 point;
    private Vector3 newpoint;
    private EState state;

    private void Start()
    {
        state = EState.Off;
        point = Point.position;
        newpoint = newPoint.position;
        CanPerform = !CanPerform;


    }
    public override void Interaction()
    {
        if (inputKeyUI == null)
        {
            inputKeyUI = FindObjectOfType<InputKeyUI>();
        }
        //isOn = !isOn;

        switch(state)
        {
            case EState.Off:
                movePointUI.OnSushiUI();
                Point.position = newpoint;
                state = EState.On;
                break;
            case EState.On:
                GameManager.Instance.LoadScene(GameManager.EScene.Sushi);
                //여기서 ESC 누르면 OFF로 가야되고
                //한 번 더 누르면 씬 넘기기
                Debug.Log("씬넘겨용");
                break;



        }
    }

    private void Update()
    {
        movePointUI.OnBoatUI(on);
        //UIOn(on);
    }

}
