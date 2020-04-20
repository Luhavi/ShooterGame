using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour {

    public float Enemynum;
    public float EnemyDienum;

    void Update()
    {
        if (Enemynum == EnemyDienum)
        {
            WaveCtrl.Endnum++;
            Destroy(this.gameObject);
        }
    }

}