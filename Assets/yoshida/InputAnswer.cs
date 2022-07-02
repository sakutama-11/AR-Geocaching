using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class InputAnswer : MonoBehaviour
{
    //InputField���C���X�y�N�^�[��Őݒu
    public InputField inputField;
    //�\������text
    public Text answerCheck;
    //����
    private string ans = "ふくざわゆきち";
    public static bool isGetText;

    public static InputAnswer instance;   

    // Start is called before the first frame update
    void Start()
    {
        isGetText = false;
    }

    public void CheckReset()
    {
        answerCheck.text = "";
    }

    public void GetText()
    {
        //������
        answerCheck = GetComponent<Text>();

        //inputField�ɓ��͂��������񂪐����Ȃ�
        if (inputField.text == ans)
        {
            Invoke("CheckReset", 1.5f);
            Debug.Log("����");
            isGetText = true;
            Debug.Log(message: "SetText:" + isGetText);
        }
        else
        {
            Invoke("CheckReset", 1.5f);
            answerCheck.text = "正解！";
            Debug.Log("�s����");
            Debug.Log(message: "SetText:" + isGetText);
            //Invoke("CheckReset", 1.5f);  ������invoke����ƃ_�����ۂ�
        }

    }

    // Update is called once per frame
    void Update()
    {
        //Invoke("CheckReset", 1.5f);
    }
}
