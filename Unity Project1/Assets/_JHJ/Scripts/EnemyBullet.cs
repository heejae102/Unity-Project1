using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private GameObject target;
    private Vector3 destPos;
    public float speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        //타겟의 방향 구하기(벡터의 뺄셈)
        //방향 = 타겟 - 자기자신
        
        target = GameObject.Find("Player");

        destPos = target.transform.position - transform.position;
        destPos.Normalize();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(destPos * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player")) Destroy(other.gameObject);

        Destroy(gameObject);
    }
}
