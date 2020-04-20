using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove2 : MonoBehaviour {

    public Transform target;
    public Vector3 direction;
    public float speed = 5f;

    private void Start()
    {
        // Player의 현재 위치를 받아오는 Object
        target = GameObject.Find("Player").transform;
        // Player의 위치와 이 객체의 위치를 빼고 단위 벡터화 한다.
        direction = (target.position - transform.position).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        direction = (target.position - transform.position).normalized;
        transform.Translate(direction * speed * Time.deltaTime);
        transform.eulerAngles = new Vector3(0, 0, -getAngle(transform.position.x, transform.position.y, target.position.x, target.position.y));
        
    }



    private float getAngle(float x1, float y1, float x2, float y2)
    {
        float dx = x2 - x1;
        float dy = y2 - y1;
        float rad = Mathf.Atan2(dx, dy);
        float degree = rad * Mathf.Rad2Deg;
        return degree;
    }
}
