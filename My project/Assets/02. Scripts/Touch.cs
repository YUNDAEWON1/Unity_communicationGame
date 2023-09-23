using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch : MonoBehaviour
{
    public AudioClip voice1;
    public AudioClip voice2;
    private Animator animator;
    private AudioSource univoice;

    //�ð��� ��¥ ���
    System.DateTime now;
    int nowYear;    //��
    int nowMonth;   //��
    int nowDay;     //��
    int nowHour;    //�ð�
    int nowMin;     //��
    int nowSec;     //��

    //��� ������Ʈ�� ID���
    private int motionIdol = Animator.StringToHash("Base Layer.Idol");
    void Start()
    {
        animator = GetComponent<Animator>();
        univoice = GetComponent<AudioSource>();

       

    }
    void Update()
    {

        //���� ��¥�� �ð� ���
        now = System.DateTime.Now;  //���� ��¥�� �ð�                               
        nowYear = now.Year;
        nowMonth = now.Month;
        nowDay = now.Day;
        nowHour = now.Hour;
        nowMin = now.Minute;
        nowSec = now.Second;


        animator.SetBool("Touch", false);
        animator.SetBool("TouchHead", false);

        //��� ���� ������ ��⵿������ �˻�
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
                    MsgDisplay.SaveMessage("�ȳ�!\n���õ� ������ �����غ���!");
                }
               else if(hitObj.tag=="Body")
                {
                    animator.SetBool("Touch", true);
                    univoice.clip = voice2;
                    univoice.Play();
                    MsgDisplay.SaveMessage("��!");
                }
               else if(hitObj.tag=="Arms")
                {
                    MsgDisplay.SaveMessage(nowYear+"��"+nowMonth+"��"+nowDay+"��\n" + nowHour+"��"+nowMin+"��"+nowSec+"��");
                }
            }
        }
    }
}
