using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //플레이어 이동
    //플레이어 사용자가 조작하므로 입력을 받아야 한다. 
    //키보드, 마우스 등등 입력은 Input 매니저가 담당 
    
    //트랜스폼은 자주 사용하기 때문에 소문자로 접근 가능 transform

    //이동속력
    public float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //GetAxis를 사용하는 이유? 멀티플랫폼 사용 때문(콘솔, 모바일, 윈도우)
        //GetAxis => -1 ~ 1 사이의 값 
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        //이동처리 방법1 
        //transform.Translate(h * speed * Time.deltaTime, v * speed * Time.deltaTime, 0f);

        //이동처리 방법2 (제일 일반적인 방법)
        //덧셈일 때는 크게 상관없지만 뺄셈을 사용할 경우 방법2가 더 좋다.
        Vector3 dir = Vector3.right * h + Vector3.forward * v;

        //벡터의 정규화(대각선의 값을 직선 방향과 같이 정규화시켜준다.)
        dir.Normalize();

        //transform.Translate(dir * speed * Time.deltaTime);

        //이동처리 방법3 ★중요★
        //일반적인 방법에 비해 드라마틱한 이동처리 가능 
        //P = P0 + vt;
        //위치 = 현재위치 + (방향 * 시간);
        transform.position = transform.position + dir * speed * Time.deltaTime;
        transform.position += dir * speed * Time.deltaTime;
    }

    //플레이어를 화면 밖으로 나가지 못하게 하기 
    //1. 화면 밖 공간에 큐브 4개를 만들어서 배치하면 충돌체때문에 밖으로 벗어나지 못함. 
    //- 리지드바디가 포함되어야 충돌처리가 가능 

    //2. 플레이어의 트랜스폼 포지션 x, y 값을 고정 

    //3. 메인카메라의 뷰포트를 가져와서 처리 
}
