using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour {
    public GameObject Life1;
    public GameObject Life2;
    public GameObject Life3;
    public GameObject Life4;
    public GameObject Life5;

    void Update () {
        if(Player.HP == 5)
        {
            Life1.SetActive(true);
            Life2.SetActive(true);
            Life3.SetActive(true);
            Life4.SetActive(true);
            Life5.SetActive(true);
        }else if (Player.HP == 4)
        {
            Life1.SetActive(true);
            Life2.SetActive(true);
            Life3.SetActive(true);
            Life4.SetActive(true);
            Life5.SetActive(false);
        }else if (Player.HP == 3)
        {
            Life1.SetActive(true);
            Life2.SetActive(true);
            Life3.SetActive(true);
            Life4.SetActive(false);
            Life5.SetActive(false);
        }else if (Player.HP == 2)
        {
            Life1.SetActive(true);
            Life2.SetActive(true);
            Life3.SetActive(false);
            Life4.SetActive(false);
            Life5.SetActive(false);
        }else if (Player.HP == 1)
        {
            Life1.SetActive(true);
            Life2.SetActive(false);
            Life3.SetActive(false);
            Life4.SetActive(false);
            Life5.SetActive(false);
        }
    }
}
