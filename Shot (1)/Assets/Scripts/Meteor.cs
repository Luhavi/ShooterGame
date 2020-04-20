using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour {

    public float xSpeed = 5.0f;
    public float ySpeed = 5.0f;

    public float AutoDie = 30f;

    // Update is called once per frame
    void Update () {
        this.gameObject.transform.Translate(1 * xSpeed * Time.deltaTime, 1 * ySpeed * Time.deltaTime, 0);
        AutoDie -= Time.deltaTime;
        if (AutoDie <= 0)
        {
            gameObject.transform.parent.GetComponent<Wave>().EnemyDienum++;
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D Col)
    {
        if (Col.gameObject.tag == "Destroyer")
        {
            Destroy(this.gameObject);
        }
    }
}
