using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MsgDisplay : MonoBehaviour
{

    public static string msg;
    public static bool flagDisplay;

    private float waitDelay;

    public RawImage Msg;
    public Text msgtext;


    void Update()
    {
        // 메시지 초기화하기
        if (flagDisplay)
        {
            waitDelay += Time.deltaTime;

            if (waitDelay > 2.0f)
            {
                flagDisplay = false;
                waitDelay = 0;

            }
            else
            {
                Msg.gameObject.SetActive(true);
            }
        }
        else
        {
            Msg.gameObject.SetActive(false);
        }

        // 메시지가 있으면 표시
        if (!string.IsNullOrEmpty(msg))
        {
            ShowMessage(msg);
            msg = null; // 메시지를 표시한 후 msg를 초기화
        }

    }
    // 외부에서 메세지 받기
    public static void SaveMessage(string msg)
    {
        MsgDisplay.msg = msg;
    }
    // 메세지 출력
    public void ShowMessage(string msg)
    {
        flagDisplay = true;
        msgtext.text = msg;
    }
}
