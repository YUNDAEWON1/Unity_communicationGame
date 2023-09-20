using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    //GameObject parent;
    public GameObject target;  //캐릭터를 연결할 타겟

    Vector3 defPosition;
    Quaternion defRotation;
    float defZoom;

    void Start()
    {
        //parent = transform.parent.gameObject;

        //카메라의 기본위치 저장
        defPosition = target.transform.position;
        defRotation = target.transform.rotation;
        defZoom = Camera.main.fieldOfView;
    }
    void Update()
    {

        //왼쪽 드래그로 카메라 이동
        if(Input.GetMouseButton(0))
        {
            target.transform.Translate(-Input.GetAxis("Mouse X") / 10,Input.GetAxis("Mouse Y") / 10, 0);
        }
        //오른쪽 드래그로 카메라 회전
        if (Input.GetMouseButton(1))
        {
            target.transform.Rotate(-Input.GetAxis("Mouse X") * 10, -Input.GetAxis("Mouse Y") * 10, 0);
        }

        //휠 회전으로 확대/축소
        if(Input.GetAxis("Mouse ScrollWheel")!=0)
        {
            Camera.main.fieldOfView += (20 * Input.GetAxis("Mouse ScrollWheel"));


            //확대와 축소의 최소,최대 값 지정하기 ( 0밑으로 내려가 캐릭터가 반전되는 상황을 막기 위함)
            if (Camera.main.fieldOfView < 10)
                Camera.main.fieldOfView = 10;
            else if (Camera.main.fieldOfView > 100)
                Camera.main.fieldOfView = 100;
        }

        //휠 클릭으로 설정 초기화
        if(Input.GetButtonDown("Jump"))
        {
            target.transform.position = defPosition; 
            target.transform.rotation = defRotation;
            Camera.main.fieldOfView = defZoom;
        }
    }
}
