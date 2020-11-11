using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tail : MonoBehaviour
{
    //2D에서 지렁이를 만들 때 꼬리가 머리를 따라다니게 해보자
    //꼬리가 타겟(플레이어)의 위치를 알고 있어야 한다. 

    public GameObject target;   //플레이어 오브젝트 
    public float speed = 3.0f;

    // Update is called once per frame
    void Update()
    {
        //타겟의 방향 구하기(벡터의 뺄셈)
        //방향 = 타겟 - 자기자신 
        Vector3 dir = target.transform.position - transform.position;

        //타겟을 향하는 방향만 정해줄 것이므로 벡터값을 노멀라이즈(크기가 1인 벡터) 시킬 것.
        dir.Normalize();
        transform.Translate(dir * speed * Time.deltaTime);
    }
}
