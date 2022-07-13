using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Basic")]
    [SerializeField] float range = 2.2f;

    [Header("Enemy")]
    [SerializeField] GameObject pfEnemy;
    [SerializeField] float enemySpawnGap = 1f;

    [Header("Yellow Coin")]
    [SerializeField] GameObject pfYellowCoin;
    [SerializeField] float minYCSpawnGap = 1f;
    [SerializeField] float maxYCSpawnGap = 3f;
    
    [Header("Blue Coin")]
    [SerializeField] GameObject pfBlueCoin;
    [SerializeField] float minBCSpawnGap = 3f;
    [SerializeField] float maxBCSpawnGap = 6f;
    
    [Header("Green Coin")]
    [SerializeField] GameObject pfGreenCoin;
    [SerializeField] float minGCSpawnGap = 6f;
    [SerializeField] float maxGCSpawnGap = 9f;

    [Header("Heart")]
    [SerializeField] GameObject pfHeart;
    [SerializeField] float minHeartSpawnGap = 10f;
    [SerializeField] float maxHeartSpawnGap = 20f;

    void Start()
    {
        StartCoroutine(SpawnEnemy());
        StartCoroutine(SpawnYellowCoin());
        StartCoroutine(SpawnBlueCoin());
        StartCoroutine(SpawnGreenCoin());
        StartCoroutine(SpawnHeart());
    }

    IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(enemySpawnGap);
        Vector2 spawnPos = transform.position + new Vector3(0, Random.Range(-range, range));
        Instantiate(pfEnemy, spawnPos, Quaternion.identity);

        StartCoroutine(SpawnEnemy());
    }
    
    IEnumerator SpawnYellowCoin()
    {
        yield return new WaitForSeconds(Random.Range(minYCSpawnGap, maxYCSpawnGap));
        Vector2 spawnPos = transform.position + new Vector3(0, Random.Range(-range, range));
        Instantiate(pfYellowCoin, spawnPos, Quaternion.identity);

        StartCoroutine(SpawnYellowCoin());
    }
        
    IEnumerator SpawnBlueCoin()
    {
        yield return new WaitForSeconds(Random.Range(minBCSpawnGap, maxBCSpawnGap));
        Vector2 spawnPos = transform.position + new Vector3(0, Random.Range(-range, range));
        Instantiate(pfBlueCoin, spawnPos, Quaternion.identity);

        StartCoroutine(SpawnBlueCoin());
    }
        
    IEnumerator SpawnGreenCoin()
    {
        yield return new WaitForSeconds(Random.Range(minGCSpawnGap, maxGCSpawnGap));
        Vector2 spawnPos = transform.position + new Vector3(0, Random.Range(-range, range));
        Instantiate(pfGreenCoin, spawnPos, Quaternion.identity);

        StartCoroutine(SpawnGreenCoin());
    }

    IEnumerator SpawnHeart()
    {
        yield return new WaitForSeconds(Random.Range(minHeartSpawnGap, maxHeartSpawnGap));
        Vector2 spawnPos = transform.position + new Vector3(0, Random.Range(-range, range));
        Instantiate(pfHeart, spawnPos, Quaternion.identity);

        StartCoroutine(SpawnHeart());
    }
}
