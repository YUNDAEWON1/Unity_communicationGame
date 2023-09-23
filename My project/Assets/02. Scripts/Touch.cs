using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch : MonoBehaviour
{
    public AudioClip voice1;
    public AudioClip voice2;
    private Animator animator;
    private AudioSource univoice;

    //시간과 날짜 얻기
    System.DateTime now;
    int nowYear;    //년
    int nowMonth;   //월
    int nowDay;     //일
    int nowHour;    //시간
    int nowMin;     //분
    int nowSec;     //초

    //모션 스테이트의 ID얻기
    private int motionIdol = Animator.StringToHash("Base Layer.Idol");
    void Start()
    {
        animator = GetComponent<Animator>();
        univoice = GetComponent<AudioSource>();

       

    }
    void Update()
    {

        //현재 날짜와 시간 얻기
        now = System.DateTime.Now;  //현재 날짜와 시간                               
        nowYear = now.Year;
        nowMonth = now.Month;
        nowDay = now.Day;
        nowHour = now.Hour;
        nowMin = now.Minute;
        nowSec = now.Second;


        animator.SetBool("Touch", false);
        animator.SetBool("TouchHead", false);

        //재생 중인 동작이 대기동작인지 검사
        if (animator.GetCurrentAnimatorStateInfo(0).fullPathHash == motionIdol)
            animator.SetBool("Motion_Idle", true);
        else
            animator.SetBool("Motion_Idle", false);


        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray,out hit,100))
            {
                GameObject hitObj = hit.collider.gameObject;

               if(hitObj.tag=="Head")
                {
                    animator.SetBool("TouchHead", true);
                    animator.SetBool("Face_Happy", true);
                    animator.SetBool("Face_Angry", false);
                    univoice.clip = voice1;
                    univoice.Play();
                    MsgDisplay.SaveMessage("안녕!\n오늘도 힘차게 시작해보자!");
                }
               else if(hitObj.tag=="Body")
                {
                    animator.SetBool("Touch", true);
                    univoice.clip = voice2;
                    univoice.Play();
                    MsgDisplay.SaveMessage("꺅!");
                }
               else if(hitObj.tag=="Arms")
                {
                    MsgDisplay.SaveMessage(nowYear+"년"+nowMonth+"월"+nowDay+"일\n" + nowHour+"시"+nowMin+"분"+nowSec+"초");
                }
            }
        }
    }
}
