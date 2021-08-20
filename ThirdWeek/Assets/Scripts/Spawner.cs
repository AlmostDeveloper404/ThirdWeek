using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static Vector3 size=new Vector3(90f,50f,0);

    [Header("SpawnObjects")]
    public ObjectsTemplate Bomb;
    public ObjectsTemplate Coin;
    public GameObject RocketPrefab;

    public Transform pointsHandler;
    private Transform[] spawnPoints;

    int currentSpawnPointIndex;




    private void Start()
    {
        spawnPoints = new Transform[pointsHandler.childCount];
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            spawnPoints[i] = pointsHandler.GetChild(i);
        }

        currentSpawnPointIndex = 0;
        CoinSpawner();
        BombSpawner();
        StartCoroutine(SpawnRocket());
    }

    

    void CoinSpawner()
    {
        for (int i = 0; i < Coin.Amount; i++)
        {
            float randomWeight = Random.Range(-size.x / 2, size.x / 2);
            float randomHeight = Random.Range(-size.y / 2, size.y / 2);
            Instantiate(Coin.ObjectPrefab, new Vector2(randomWeight, randomHeight), Quaternion.identity);
        }
    }

    void BombSpawner()
    {
        for (int i = 0; i < Bomb.Amount; i++)
        {
            float randomWeight = Random.Range(-size.x / 2, size.x / 2);
            float randomHeight = Random.Range(-size.y / 2, size.y / 2);
            Instantiate(Bomb.ObjectPrefab, new Vector2(randomWeight, randomHeight), Quaternion.identity);
        }
    }

    IEnumerator SpawnRocket()
    {
        while (true)
        {
            Instantiate(RocketPrefab,spawnPoints[currentSpawnPointIndex].position,Quaternion.identity);
            yield return new WaitForSeconds(10f);
            Debug.Log("Yep");
            
            if (currentSpawnPointIndex>spawnPoints.Length-1)
            {
                currentSpawnPointIndex = 0;
            }
            currentSpawnPointIndex++;
            
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0f, 0f, 0f, 0.2f);
        Gizmos.DrawCube(transform.position, size);
    }
}
