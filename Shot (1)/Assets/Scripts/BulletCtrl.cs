using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : MonoBehaviour {
    public GameObject JoystickBg;
    public GameObject Joystick;
    public float Speed = 5.0f;
    Vector2 dir;
    public int HP = 1;

    void OnTriggerEnter2D(Collider2D Col)
    {
        if (Col.gameObject.tag == "Destroyer")
        {
            Destroy(this.gameObject);
        }
        if (Col.gameObject.tag == "Enemy")
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
        GameObject JoystickBg = GameObject.Find("ShotJoyBack");
        GameObject Joystick = GameObject.Find("ShotJoyStick");
        dir = (Joystick.transform.position - JoystickBg.transform.position).normalized;
    }

	void Update () {
        this.gameObject.transform.Translate(dir * Speed * Time.deltaTime);
	}
}
