using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class Spawner : MonoBehaviour
{
    public Liquid Tea;
    public Transform SpawnPoint;
    public ParticleSystem Smoke;

    private List<Liquid> circles;
    private int randNum;
    private int count;
    private Vector3 spawnPoint;
    private Liquid tea;

    private void Awake()
    {
        circles = new List<Liquid>();
        count = 0;
        MakeTea();
        //StartCoroutine(dd());
    }

    private void MakeTea()
    {
        for(int i=0; i<300; i++)
        {
            randNum = Random.Range(0, 1);
            spawnPoint = randNum == 0 ? transform.position : SpawnPoint.position;

            tea = Instantiate(Tea, spawnPoint, Quaternion.identity);
            tea.transform.SetParent(transform);
            tea.gameObject.SetActive(false);
            circles.Add(tea);
        }

    }

    public void SpawnTea()
    {
        for(int i=0; i<3; i++)
        {
            circles[count].gameObject.SetActive(true);
            count++;
        }

        if(count.Equals(90))
        {
            Smoke.Play();
        }
        
    }

    /*    public async UniTaskVoid UniWait()
        {
            Instantiate(trans, transform.position, Quaternion.identity);
            Instantiate(trans, trans2.position, Quaternion.identity);
            await UniTask.Delay(20, cancellationToken:System.Threading.CancellationToken.None);   
        }*/
}
