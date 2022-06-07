using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class InputAnswer : MonoBehaviour
{
    //InputFieldをインスペクター上で設置
    public InputField inputField;
    //表示するtext
    public Text answerCheck;
    //答え
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
        //初期化
        answerCheck = GetComponent<Text>();

        //inputFieldに入力した文字列が正解なら
        if (inputField.text == ans)
        {
            Invoke("CheckReset", 1.5f);
            Debug.Log("正解");
            isGetText = true;
            Debug.Log(message: "SetText:" + isGetText);
        }
        else
        {
            Invoke("CheckReset", 1.5f);
            answerCheck.text = "不正解";
            Debug.Log("不正解");
            Debug.Log(message: "SetText:" + isGetText);
            //Invoke("CheckReset", 1.5f);  ここにinvokeあるとダメっぽい
        }

    }

    // Update is called once per frame
    void Update()
    {
        //Invoke("CheckReset", 1.5f);
    }
}
