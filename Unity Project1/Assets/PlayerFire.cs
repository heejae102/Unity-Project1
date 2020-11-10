using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject bulletFactory;    //총알 공장(프리팹)
    public Transform firePoint;
    private bool planeOn = false; 

    // Update is called once per frame
    void Update()
    {
        Fire();

        TogglePlanes();
    }

    private void Fire()
    {
        //마우스 왼쪽버튼 or 왼쪽컨트롤 키 
        if(Input.GetButtonDown("Fire1"))
        {
            //총알공장(총알프리팹)에서 총알을 무한히 찍어낼 수 있다. 

            //총알 게임오브젝트 생성
            GameObject bullet = Instantiate(bulletFactory);

            //총알 오브젝트의 위치 지정
            bullet.transform.position = firePoint.position;
        }

        //GetMouseButton(0) => 마우스 왼쪽버튼 
        //GetMouseButton(1) => 마우스 오른쪽버튼 
        //GetMouseButton(2) => 마우스 미들버튼(휠버튼)
    }

    void TogglePlanes()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            foreach(Transform child in transform)
            {
                if(child.tag.Equals("Airplane"))
                {
                    if (planeOn) child.gameObject.SetActive(false);                    
                    else child.gameObject.SetActive(true);                   
                }
            }

            if (planeOn) planeOn = false;
            else planeOn = true;
        }
    }
}
