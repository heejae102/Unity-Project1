using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
//자동으로 원하는 컴포넌트를 추가한다. 
//반드시 필요한 컴포넌트를 실수로 삭제하지 않도록 강제성을 부여 

public class Enemy : MonoBehaviour
{
    //에너미의 역할?
    //똥피하기 느낌으로 위에서 아래로 떨어진다.
    //에너미가 플레이어를 향해서 총알을 발사한다. 
    //충돌처리 - 리지드바디 사용할 것

    public GameObject bulletPrefab;
    public GameObject player;
    public float speed = 5.0f;  //에너미 이동속도
    public float spawnTerm; 
    private float curTime;

    private void Start()
    {
        player = FindObjectOfType<PlayerMove>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        //아래로 이동 
        transform.Translate(Vector3.back * speed * Time.deltaTime);

        if (gameObject.activeSelf == true && player.activeSelf == true)
        {
            FireBullet();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //자기자신을 없애고 충돌한 오브젝트도 없앤다. 
        if(collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }

    void FireBullet()
    {
        curTime += Time.deltaTime;

        if(curTime > spawnTerm)
        {
            curTime = 0.0f;
            GameObject bullet = Instantiate(bulletPrefab);
            Vector3 bulletPos = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1.5f);
            bullet.transform.position = bulletPos;
            //bullet.transform.position = transform.position;
        }
    }
}
