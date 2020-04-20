using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;


public class Enemy : MonoBehaviour {

    public int HP = 5;
    public Transform[] firePos;
    public float delaytime = 0.5f;
    public GameObject bullet;
    public GameObject Explosion;

    private float TickTime;
    private bool shot = false;

    public float AutoDie = 10f;
    
                

    void Update()
    {
        TickTime += Time.deltaTime;

        if (TickTime >= delaytime && shot)
        {
            for (int i = 0; i < firePos.Length; i++)
            {
                Instantiate(bullet, firePos[i].position, firePos[i].rotation);
            }

            TickTime = 0;
        }
            Vector3 worldpos = Camera.main.WorldToViewportPoint(this.transform.position);
            if (worldpos.x >= 0 && worldpos.y >= 0 && worldpos.x <= 1 && worldpos.y <= 1)
        {
            shot = true;
        }
        else
        {
            shot = false;
        }
        AutoDie -= Time.deltaTime;
        if (AutoDie <= 0)
        {
            gameObject.transform.parent.GetComponent<Wave>().EnemyDienum++;
            Destroy(this.gameObject);
        }

    }

    void OnTriggerEnter2D(Collider2D Col)
    {
        if (Col.gameObject.tag == "PlayerBullet")
        {
            HP--;

            if (HP == 0) {
                Instantiate(Explosion, transform.position, transform.rotation);
                gameObject.transform.parent.GetComponent<Wave>().EnemyDienum++;
                Destroy(this.gameObject);
            }
        }
        if (Col.gameObject.tag == "Destroyer")
        {
            HP = 0;

            if (HP == 0)
            {
                Instantiate(Explosion, transform.position, transform.rotation);
                gameObject.transform.parent.GetComponent<Wave>().EnemyDienum++;
                Destroy(this.gameObject);
            }
        }
    }
}
