using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : DontDestroySingleton<GameManager>
{

    [SerializeField] private Image loadScene;

    public static string NextSceneName => nextSceneName;
    private static string nextSceneName;
    public enum EScene
    { 
        Loading, SushiToLobby, UnderWaterToLobby, UnderWater, Sushi
    }
    private EScene scene;
    public EScene Scene => scene;
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
                nextSceneName = "SushiScene";
                break;
        }
        LoadingScene();

    }

    private void LoadingScene()
    {
        //로비로 갈땐 로딩씬이 없다
        string sceneName = scene == EScene.SushiToLobby ? "LobbyScene" : "LoadingScene";
        loadScene.enabled = true;
        loadScene.DOFade(1, 3).OnComplete(() => SceneManager.LoadScene(sceneName));
    }


    
}
