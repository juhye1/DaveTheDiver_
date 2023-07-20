using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class LoadingUI : MonoBehaviour
{
    private string NextScene => GameManager.NextSceneName;
    private CanvasGroup CanvasGroup;
    private GameManager.EScene scene;
    [SerializeField] private Image[] images;
    [SerializeField] private GameObject[] Marlin;
    [SerializeField] private Image line;
    [SerializeField] private Sprite[] lineSprites;
    [SerializeField] private TextMeshProUGUI tipTMP;
    private string SushiTip;
    private string UnderWaterTip;
    private void Awake()
    {
        CanvasGroup = GetComponentInChildren<CanvasGroup>();
        CanvasGroup.alpha = 0;
        scene = GameManager.Instance.Scene;
        Tip();
    }
    private void Start()
    {
        GameManager.Instance.ResetLoadSceneEffect();

        switch(scene)
        {
            case GameManager.EScene.Sushi:
                images[0].enabled = true;
                line.sprite = lineSprites[0];
                tipTMP.text = SushiTip;
                break;
            case GameManager.EScene.UnderWater:
                Marlin[0].SetActive(true);
                Marlin[1].SetActive(true);
                line.sprite = lineSprites[1];
                tipTMP.text = UnderWaterTip;
                break;
        }


        CanvasGroup.DOFade(1, 0.5f).OnComplete(() => StartCoroutine(LoadScene()));
    }

    private IEnumerator LoadScene()
    {
        yield return null;
        AsyncOperation op = SceneManager.LoadSceneAsync(NextScene);
        op.allowSceneActivation = false;
        while (!op.isDone)
        {
            yield return null;
            if (op.progress < 0.9f)
            {
            }
            else
            {
                yield return new WaitForSeconds(0.1f);
                op.allowSceneActivation = true;
                yield break;

            }
        }
    }

    private void Tip()
    {
        SushiTip = "영업 후 메뉴에 남은 재료는 모두 폐기하게 됩니다. 너무 많이 등록하지 마세요!";
        UnderWaterTip = "물 속에서 사망할 경우 한 개의 아이템만 회수할 수 있습니다.";
    }
}
