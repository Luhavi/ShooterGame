using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Shot : MonoBehaviour {

    public Transform Stick;
    public GameObject bullet;
    public Transform firePos;
    public float delaytime = 0.5f;
    public AudioClip shotsound;

    private AudioSource myAudio;
    private float TickTime;
    private Vector2 dir;
    private Vector3 StickFirstPos;
    private Vector3 JoyVec;
    private float Radius;
    private bool ShotFlog;

    void Start()
    {

        Radius = GetComponent<RectTransform>().sizeDelta.y * 0.5f;
        StickFirstPos = Stick.transform.position;

        float Can = transform.parent.GetComponent<RectTransform>().localScale.x;
        Radius *= Can;

        ShotFlog = false;

        firePos = GameObject.Find("Player").transform;
        myAudio = GetComponent<AudioSource>();
        

    }

    void Update()
    {
        TickTime += Time.deltaTime;
        if (TickTime >= delaytime)
        {
            if (ShotFlog)
            {
                Instantiate(bullet, firePos.position, firePos.rotation);
                myAudio.PlayOneShot(shotsound);
            }
            TickTime = 0;
        }
    }

    public void Drag(BaseEventData _Data)
    {
        ShotFlog = true;
        PointerEventData Data = _Data as PointerEventData;
        Vector3 Pos = Data.position;

        JoyVec = (Pos - StickFirstPos).normalized;

        float Dis = Vector3.Distance(Pos, StickFirstPos);

        if (Dis < Radius)
            Stick.position = StickFirstPos + JoyVec * Dis;
        else
            Stick.position = StickFirstPos + JoyVec * Radius;
    }
    public void DragEnd()
    {
        Stick.position = StickFirstPos; // 스틱을 원래의 위치로.
        JoyVec = Vector3.zero;          // 방향을 0으로.
        ShotFlog = false;
    }
}
