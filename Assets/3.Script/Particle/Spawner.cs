using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform trans;

    private void Awake()
    {
        //StartCoroutine(dd());
    }
    private void Start()
    {
        
    }

    private IEnumerator dd()
    {
        WaitForSeconds dd = new WaitForSeconds(0.02f);

        for (int i = 0; i < 100; i++)

        {
            Instantiate(trans, transform.position, Quaternion.identity);
        yield return dd;
        }
    }
}
