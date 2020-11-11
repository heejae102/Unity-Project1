using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClone : MonoBehaviour
{
    //아이템을 먹어서 보조비행기가 생기도록 해야 함. 
    //보조비행기는 일정 시간마다 자동으로 총알을 발사 함. 

    public GameObject clone;
    public GameObject bulletFactory;    //총알공장
    public float fireTime = 1.0f;       //1초에 한번씩 총알 발사     
    float curTime = 0.0f;               //누적 경과시간 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //아이템을 먹으면 보조비행기 생성 
        CreateClone();

        //총알 발사 
        AutoFire();
    }

    private void AutoFire()
    {
        //클론이 액티브 상태일 때 총알 자동발사 하기 
        if(clone.activeSelf)
        {
            //일정시간이 흐르면 총알을 발사해야 한다. 
            curTime += Time.deltaTime;

            if(curTime > fireTime)
            {
                //현재시간 0으로 초기화 
                curTime = 0f;

                //GameObject bullet = Instantiate(bulletFactory);
                //bullet.transform.position = GameObject.Find("Sub1").transform.position;
                //bullet.transform.position = clone.transform.Find("Sub1").position;
                //bullet.transform.position = clone.transform.GetChild(0).position;

                //GameObject[] bullet = new GameObject[2];
                GameObject[] bullet = new GameObject[clone.transform.childCount];

                for(int i=0; i<clone.transform.childCount; i++)
                {
                    bullet[i] = Instantiate(bulletFactory);

                    Transform childPos = clone.transform.GetChild(i).transform;
                    Vector3 firePos = new Vector3(childPos.position.x, childPos.position.y, childPos.position.z + 1.5f);
                    bullet[i].transform.position = firePos;
                }
            }
        }
    }

    void CreateClone()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //clone.SetActive(true);
            if (clone.activeSelf == false) clone.SetActive(true);
            else clone.SetActive(false);
        }
    }
}
