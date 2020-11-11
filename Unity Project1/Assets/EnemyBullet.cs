using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public Transform target;
    public float speed = 5.0f;
    private Vector3 destPos;

    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<PlayerMove>().transform;
        destPos = target.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(destPos * speed * Time.deltaTime);
    }
}
