using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidSpawner : MonoBehaviour
{
    [Header("물고기")]
    [SerializeField] private Boid YellowTang;
    [SerializeField] private Boid ClownFish;
    [SerializeField] private Boid Comber;
    [SerializeField] private Boid JellyFish;
    [SerializeField] private Boid ButterflyFish;
    [SerializeField] private Boid BatFish;
    [SerializeField] private Boid Anthias;

    private List<Boid> boids;
    private int num = 0;
    private bool isStart = false;
    [Header("스폰 설정")]
    [SerializeField] private float spawnRadius = 10;

    [Header("스폰 위치")]
    [SerializeField] private Transform[] SpawnPoint;
    private void Start()
    {
        SpawnBoid(YellowTang,5);
        SpawnBoid(ClownFish,3);
        SpawnBoid(Comber,5);
        SpawnBoid(JellyFish,5);
        SpawnBoid(ButterflyFish,3);
        SpawnBoid(BatFish,3);
        SpawnBoid(Anthias, 5);
        isStart = !isStart;
    }

    private void SpawnBoid(Boid prefab, int spawnCount)
    {
        for (int i = 0; i < spawnCount; i++)
        {
            Vector3 pos = SpawnPoint[num].position + Random.insideUnitSphere * spawnRadius;
            Boid boid = Instantiate(prefab);
            boid.transform.SetParent(SpawnPoint[num]);
            boid.transform.position = new Vector2(pos.x, pos.y);
            boid.transform.right = Random.insideUnitSphere;
        }
        num++;
    }
    private void Update()
    {
        if (isStart) UpdateSpawnPoint();

    }

    private void UpdateSpawnPoint()
    {
        for (int i = 0; i < SpawnPoint.Length; i++)
        {
            num = i + 1;
            if (num == SpawnPoint.Length)
            {
                num = 0;
            }
            SpawnPoint[i].localPosition = Vector2.MoveTowards(SpawnPoint[i].localPosition, SpawnPoint[num].localPosition, Time.deltaTime*0.1f);

        }
    }
}
