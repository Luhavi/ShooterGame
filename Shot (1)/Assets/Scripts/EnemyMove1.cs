using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove1 : MonoBehaviour {
    public float Speed = 1.0f;

	void Update () {
        this.gameObject.transform.Translate(Vector2.up * Speed * Time.deltaTime);
		
	}
}
