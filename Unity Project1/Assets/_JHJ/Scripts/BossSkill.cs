using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSkill : MonoBehaviour
{
    public GameObject prefab;
    float count;
    public float maxCount = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        count += Time.deltaTime;

        if(count > maxCount)
        {
            count = 0;

            for(int i = 0; i < 36; i++)
            {
                Instantiate(prefab, transform.position, Quaternion.Euler(0f, 10 * i, 0f));
            }
        }
    }
}
