using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour{

    public GameObject player;
    public Transform Stick;
    public float MoveSpeed = 5.0f;
    
    private Vector3 StickFirstPos;
    private Vector3 JoyVec;
    private float Radius;
    private bool MoveFlog;

    void Start()
    {

        Radius = GetComponent<RectTransform>().sizeDelta.y * 0.5f;
        StickFirstPos = Stick.transform.position;

        float Can = transform.parent.GetComponent<RectTransform>().localScale.x;
        Radius *= Can;

        MoveFlog = false;

        player = GameObject.Find("Player");

    }

    void Update()
    {
            if (MoveFlog)
        {
            player.gameObject.transform.Translate(JoyVec * MoveSpeed * Time.deltaTime);
        }
                
    }

    public void Drag(BaseEventData _Data)
    {
        MoveFlog = true;
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
        MoveFlog = false;
    }
}
