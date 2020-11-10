using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    public GameObject bulletObj;
    private Transform spawnPos;
    public float spawnRate;

    private void Start()
    {
        spawnRate = 0f;
        spawnPos = transform.Find("SpawnPos").transform;
    }

    // Update is called once per frame
    void Update()
    {
        spawnRate += Time.deltaTime;

        if(spawnRate >= 1f)
        {
            spawnRate = 0f;

            GameObject bullet = Instantiate(bulletObj);
            bullet.transform.position = spawnPos.position;
        }
    }
}
