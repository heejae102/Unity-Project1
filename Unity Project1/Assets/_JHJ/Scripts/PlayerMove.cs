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
    public Vector2 margin; //뷰포트좌표는 (0,0) ~ (1,1)

    float camWidth;
    float camHeight;
    float playerHalfWidth;
    float playerHalfHeight;

    // Start is called before the first frame update
    void Start()
    {
        //camHeight = Camera.main.orthographicSize;
        //camWidth = camHeight * Screen.width / Screen.height;

        //Vector3 colHalfSize = GetComponent<Collider>().bounds.extents;
        //playerHalfWidth = colHalfSize.x;
        //playerHalfHeight = colHalfSize.z;

        camHeight = Camera.main.orthographicSize;
        camWidth = camHeight * Screen.width / Screen.height;

        Vector3 colHalfSize = GetComponent<Collider>().bounds.extents;
    }

    // Update is called once per frame
    void Update()
    {
        //GetAxis를 사용하는 이유? 멀티플랫폼 사용 때문(콘솔, 모바일, 윈도우)
        //GetAxis => -1 ~ 1 사이의 값 
        //float h = Input.GetAxis("Horizontal");
        //float v = Input.GetAxis("Vertical");

        //이동처리 방법1 
        //transform.Translate(h * speed * Time.deltaTime, v * speed * Time.deltaTime, 0f);

        //이동처리 방법2 (제일 일반적인 방법)
        //덧셈일 때는 크게 상관없지만 뺄셈을 사용할 경우 방법2가 더 좋다.
        //Vector3 dir = Vector3.right * h + Vector3.forward * v;
        //Vector3 dir = new Vector3(h, 0f, v);

        //벡터의 정규화(대각선의 값을 직선 방향과 같이 정규화시켜준다.)
        //dir.Normalize();

        //transform.Translate(dir * speed * Time.deltaTime);

        //이동처리 방법3 ★중요★
        //일반적인 방법에 비해 드라마틱한 이동처리 가능 
        //P = P0 + vt;
        //위치 = 현재위치 + (방향 * 시간);
        //transform.position = transform.position + dir * speed * Time.deltaTime;
        //transform.position += dir * speed * Time.deltaTime;
        //FixPlayerPosX();
        //FixPlayerPosZ();

        //FixCameraPos(transform.position);

        MoveControl();
    }

    //플레이어를 화면 밖으로 나가지 못하게 하기 
    //1. 화면 밖 공간에 큐브 4개를 만들어서 배치하면 충돌체때문에 밖으로 벗어나지 못함. 
    //- 리지드바디가 포함되어야 충돌처리가 가능 

    //2. 플레이어의 트랜스폼 포지션 x, y 값을 고정 

    //3. 메인카메라의 뷰포트를 가져와서 처리 
    //스크린 좌표 : 모니터해상도 픽셀단위
    //뷰포트 좌표 : 카메라의 사각뿔 끝에 있는 사각형 왼쪽하단(0,0), 우측상단(1,1)
    //UV 좌표 : 화면 텍스트, 2D 이미지를 표시하기 위한 좌표계로 텍스쳐좌표계라고도 한다. 
    //좌상단(0,0), 우측하단(1,1)

    void FixPlayerPosX()
    {
        if (transform.position.x <= -4.5f)
        {
            Vector3 tempPos = new Vector3(-4.5f, transform.position.y, transform.position.z);
            transform.position = tempPos;
        }
        else if (transform.position.x >= 4.5f)
        {
            Vector3 tempPos = new Vector3(4.5f, transform.position.y, transform.position.z);
            transform.position = tempPos;
        }
    }

    void FixPlayerPosZ()
    {
        if (transform.position.z <= -4.5f)
        {
            Vector3 tempPos = new Vector3(transform.position.x, transform.position.y, -4.5f);
            transform.position = tempPos;
        }
        else if (transform.position.z >= 4.5f)
        {
            Vector3 tempPos = new Vector3(transform.position.x, transform.position.y, 4.5f);
            transform.position = tempPos;
        }
    }

    void FixPlayerPos()
    {
        Vector3 playerPos = transform.position;

        playerPos.x = Mathf.Clamp(playerPos.x, -4.5f, 4.5f);
        playerPos.z = Mathf.Clamp(playerPos.z, -4.5f, 4.5f);

        transform.position = playerPos;
    }

    void MoveControl()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = Vector3.right * h + Vector3.forward * v;
        dir = dir.normalized;

        Vector3 movePosition = transform.position + dir * speed * Time.deltaTime;
        movePosition.Set(Mathf.Clamp(movePosition.x, -camWidth + playerHalfWidth, camWidth - playerHalfWidth), transform.position.y,
                         Mathf.Clamp(movePosition.z, -camHeight + playerHalfHeight, camHeight - playerHalfHeight));

        transform.position = movePosition;
    }

    void MoveInScreen()
    {
        //position 값에는 직접 대입이 불가능 
        //if (trasnform.position.x < 2.5f) transform.position.x = 2.5f;
        //아래와 같이 벡터3 변수를 만들어서 트랜스폼의 포지션 벡터 값을 대입 후 
        //연산해서 다시 트랜스폼에 넣어주는 것을 캐싱이라고 한다. 
        Vector3 position = transform.position;
        //if (position.x < 2.5f) position.x = 2.5f;

        //아래 방법이 훨씬 성능이 뛰어난 방법(최적화)
        //사용하지 않는 함수는 항상 삭제 
        position.x = Mathf.Clamp(position.x, -2.3f, 2.3f);
        position.z = Mathf.Clamp(position.z, -3.3f, 3.3f);

        transform.position = position;
    }

    void MoveCameraPos()
    {
        Vector3 position = Camera.main.WorldToViewportPoint(transform.position);
        position.x = Mathf.Clamp(position.x, 0.0f + margin.x, 1.0f - margin.x);
        position.z = Mathf.Clamp(position.z, 0.0f + margin.y, 1.0f - margin.y);

        transform.position = Camera.main.ViewportToWorldPoint(position);
    }

    /*
    메인 카메라의 중요함수 

    메인 카메라 또한 자주 사용하기 때문에 어디서든 접근할 수 있도록 Camera.main으로 접근 가능

    1.ScreenToViewportPoint
    - Transform.

    */
}
