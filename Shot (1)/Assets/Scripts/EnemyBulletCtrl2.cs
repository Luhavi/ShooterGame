using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletCtrl2 : MonoBehaviour {


    public Transform target;
    public Vector3 direction;
    public float Speed = 5.0f;
    public int HP = 1;

    void OnTriggerEnter2D(Collider2D Col)
    {
        if (Col.gameObject.tag == "Destroyer")
        {
            Destroy(this.gameObject);
        }
        if (Col.gameObject.tag == "Player")
        {
            HP--;

            if (HP == 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
    void Start()
    {
        target = GameObject.Find("Player").transform;
        direction = (target.position - transform.position).normalized;
    }

    void Update()
    {
        this.gameObject.transform.Translate(direction * Speed * Time.deltaTime);
    }
}
