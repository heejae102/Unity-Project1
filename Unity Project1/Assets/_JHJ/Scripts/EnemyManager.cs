using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    ////enemy spawn position
    //public GameObject enemyPrefab;
    //public float spawnTerm;
    //float curTime;
    //Transform spawnPos;

    //// Start is called before the first frame update
    //void Start()
    //{
    //    spawnPos = transform.GetChild(0);
    //    spawnTerm = 1.0f;
    //    curTime = 0.0f;
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    SpawnEnemy();
    //}

    //void SpawnEnemy()
    //{
    //    curTime += Time.deltaTime;

    //    if(curTime > spawnTerm)
    //    {
    //        curTime = 0.0f;
    //        GameObject enemy = Instantiate(enemyPrefab);
    //    }
    //}

    //에너미 매니저의 역할 : 에너미들을 반복해서 스폰(에너미 프리팹)
    //에너미 스폰타임 - 랜덤처리 
    //에너미 스폰위치 - 화면 위에 배치 

    public GameObject BossPrefab;       //보스 프리팹 
    public GameObject enemyFactory;     //에너미 공장(에너미 프리팹)
    public GameObject[] spawnPoint;     //스폰위치 여러개
    public int spawnCountBeforeBoss;    //보스 등장 전 에너미 스폰 횟수 
    private int spawnCount = 0;         //에너미 스폰 횟수     
    public float spawnTime = 1.0f;      //스폰시간(몇 초에 한번씩 찍어낼거냐?)
    float curTime = 0.0f;

    private void Update()
    {
        SpawnEnemy();
        SpawnBoss();
    }

    void SpawnEnemy()
    {
        //몇초에 한번씩 이벤트 발동 
        //누적시간으로 계산 
        //게임에서 자주 사용

        curTime += Time.deltaTime;

        if(curTime > spawnTime && spawnCount < spawnCountBeforeBoss)
        {
            //누적된 현재 시간을 0초로 초기화(반드시 해주어야 함)
            curTime = 0.0f;

            spawnCount++;

            //스폰시간을 랜덤으로 처리
            spawnTime = Random.Range(1.0f, 2.0f);

            //에너미 생성 
            GameObject enemy = Instantiate(enemyFactory);

            int index = Random.Range(0, spawnPoint.Length);
            //enemy.transform.position = spawnPoint[index].transform.position;
            enemy.transform.position = transform.GetChild(index).position;
        }
    }

    void SpawnBoss()
    {
        if (spawnCount == spawnCountBeforeBoss)
        {
            //스폰 횟수 증가(더 이상 보스 스폰하지 않도록)
            spawnCount++;

            GameObject boss = Instantiate(BossPrefab);
            boss.transform.position = transform.GetChild(3).position;
        }
    }
}
