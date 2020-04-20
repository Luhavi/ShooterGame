using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    public static int HP = 5;

    void Update()
    {
        Vector3 worldpos = Camera.main.WorldToViewportPoint(this.transform.position);
        if (worldpos.x < 0.05f) worldpos.x = 0.05f;
        if (worldpos.y < 0.05f) worldpos.y = 0.05f;
        if (worldpos.x > 0.95f) worldpos.x = 0.95f;
        if (worldpos.y > 0.95f) worldpos.y = 0.95f;
        this.transform.position = Camera.main.ViewportToWorldPoint(worldpos);
    }

    void OnTriggerEnter2D(Collider2D Col)
    {
        if (Col.gameObject.tag == "Destroyer")
        {
            HP = 0;
        }
        if (Col.gameObject.tag == "EnemyBullet")
        {
            HP--;
        }
        if (HP == 0)
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene("GameOver");
        }
    }
}
