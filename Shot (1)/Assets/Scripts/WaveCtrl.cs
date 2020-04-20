using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaveCtrl : MonoBehaviour {
    
    public GameObject[] Wave;
    public static float Endnum;
    public float delaytime = 3f;
    public float Ndelaytime = 15f;
    int i = 0;

    void Start()
    {
        InvokeRepeating("WaveSpawn", delaytime, Ndelaytime);
    }

    void Update()
    {
        if (i == Wave.Length)
        {
            CancelInvoke("WaveSpawn");
        }
        if (Endnum == Wave.Length)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    void WaveSpawn()
    {
        Instantiate(Wave[i], transform.position, Quaternion.identity);
        i++;
    }

    //public void WaveEnd()
    //{
    //    Endnum++;
    //}
}
