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
        // �޽��� �ʱ�ȭ�ϱ�
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

        // �޽����� ������ ǥ��
        if (!string.IsNullOrEmpty(msg))
        {
            ShowMessage(msg);
            msg = null; // �޽����� ǥ���� �� msg�� �ʱ�ȭ
        }

    }
    // �ܺο��� �޼��� �ޱ�
    public static void SaveMessage(string msg)
    {
        MsgDisplay.msg = msg;
    }
    // �޼��� ���
    public void ShowMessage(string msg)
    {
        flagDisplay = true;
        msgtext.text = msg;
    }
}
