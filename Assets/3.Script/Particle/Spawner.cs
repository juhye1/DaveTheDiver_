using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class Spawner : MonoBehaviour
{
    public Transform trans;

    private void Awake()
    {
        //StartCoroutine(dd());
    }


    public void PourTea()
    {
        StartCoroutine(dd());
    }
    private IEnumerator dd()
    {
        WaitForSeconds dd = new WaitForSeconds(0.2f);

        Instantiate(trans, transform.position, Quaternion.identity);
        yield return dd;
        
    }

    public async UniTaskVoid UniWait()
    {
        Instantiate(trans, transform.position, Quaternion.identity);
        await UniTask.DelayFrame(100);
    }
}
