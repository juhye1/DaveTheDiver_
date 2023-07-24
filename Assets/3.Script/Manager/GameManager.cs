using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : DontDestroySingleton<GameManager>
{

    [SerializeField] private Image loadSceneWhite;
    [SerializeField] private Image loadSceneBlack;

    public static string NextSceneName => nextSceneName;
    private static string nextSceneName;
    public enum EScene
    { 
        Loading, SushiToLobby, UnderWaterToLobby, UnderWater, Sushi
    }
    [SerializeField]  private EScene scene;
    public EScene Scene => scene;

    private void Start()
    {
        int setWidth = 1920;
        int setHeight = 1080;

        Screen.SetResolution(setWidth, setHeight, true);
    }
    public void LoadScene(EScene scene)
    {
        this.scene = scene;
        switch (scene)
        {
            case EScene.SushiToLobby:
                nextSceneName = "LobbyScene";
                break;
            case EScene.UnderWaterToLobby:
                nextSceneName = "LobbyScene";
                break;
            case EScene.UnderWater:
                nextSceneName = "UnderWaterScene";
                break;
            case EScene.Sushi:
                SoundManager.Instance.PlaySE(ESE.Lobby_Boat_Move);
                nextSceneName = "SushiScene";
                break;
        }
        LoadingScene();

    }

    private void LoadingScene()
    {
        //로비로 갈땐 로딩씬이 없다
        string sceneName = scene == EScene.SushiToLobby || scene == EScene.UnderWaterToLobby 
                                    ? "LobbyScene" : "LoadingScene";
        loadSceneWhite.enabled = true;
        loadSceneWhite.DOFade(1, 1).OnComplete(() => SceneManager.LoadScene(sceneName));
    }



    //다음씬에서 해주기
    public void ResetLoadSceneEffect()
    {
        SoundManager.Instance.StopBgm();
        Color color = loadSceneWhite.color;
        color.a = 0;
        loadSceneWhite.color = color;
        loadSceneWhite.enabled = false;
    }

    public void LoadSceneEffect()
    {
        loadSceneBlack.color = Color.black;
        loadSceneBlack.enabled = true;
        loadSceneBlack.DOFade(0, 1);
    }
    
}
