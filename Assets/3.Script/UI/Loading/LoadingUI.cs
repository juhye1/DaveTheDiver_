using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;


public class LoadingUI : MonoBehaviour
{
    private string NextScene => GameManager.NextSceneName;
    private CanvasGroup CanvasGroup;
    private void Awake()
    {
        CanvasGroup = GetComponentInChildren<CanvasGroup>();
        CanvasGroup.alpha = 0;
    }
    private void Start()
    {
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
                yield return new WaitForSeconds(3.0f);
                op.allowSceneActivation = true;
                yield break;

            }
        }
    }
}
