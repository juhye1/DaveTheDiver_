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
        Loading, Lobby, UnderWater, Sushi
    }

    public void LoadScene(EScene scene)
    {
        switch (scene)
        {
            case EScene.Lobby:
                nextSceneName = "LobbyScene";
                break;
            case EScene.UnderWater:
                nextSceneName = "UnderWaterScene";
                break;

            case EScene.Sushi:
                nextSceneName = "SushiScene";
                break;
        }

        loadScene.enabled = true;
        loadScene.DOFade(1, 3).OnComplete(() => SceneManager.LoadScene("LoadingScene"));

    }


    
}
