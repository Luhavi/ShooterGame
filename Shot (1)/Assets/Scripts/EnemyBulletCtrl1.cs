using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletCtrl1 : MonoBehaviour {
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

    void Update()
    {
        this.gameObject.transform.Translate(Vector2.up * Speed * Time.deltaTime);
    }
}
