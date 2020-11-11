using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    //enemy spawn position
    public GameObject enemyPrefab;
    public float spawnTerm;
    float curTime;
    Transform spawnPos;

    // Start is called before the first frame update
    void Start()
    {
        spawnPos = transform.GetChild(0);
        spawnTerm = 1.0f;
        curTime = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        SpawnEnemy();
    }

    void SpawnEnemy()
    {
        curTime += Time.deltaTime;

        if(curTime > spawnTerm)
        {
            curTime = 0.0f;
            GameObject enemy = Instantiate(enemyPrefab);
        }
    }
}
