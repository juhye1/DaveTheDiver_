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

    private List<Boid> boids;
    private int num = 0;
    [Header("스폰 설정")]
    [SerializeField] private float spawnRadius = 10;

    [Header("스폰 위치")]
    [SerializeField] private Transform[] SpawnPoint;
    private void Start()
    {
        SpawnBoid(YellowTang,5);
        SpawnBoid(ClownFish,3);
        SpawnBoid(Comber,10);
        SpawnBoid(JellyFish,5);
        SpawnBoid(ButterflyFish,3);
        SpawnBoid(BatFish,1);
        //스폰,,
/*        for (int i = 0; i < spawnCount; i++)
        {
            Vector3 pos = SpawnPoint[0].position + Random.insideUnitSphere * spawnRadius;
            Boid boid = Instantiate(YellowTang);
            boid.transform.SetParent(SpawnPoint[0]);
            boid.transform.position = new Vector2(pos.x, pos.y);
            boid.transform.right = Random.insideUnitSphere;
        }*/
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
}
