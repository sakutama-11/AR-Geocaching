using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class GetQuiz : MonoBehaviour
{
    //InputFieldをインスペクター上で設置
    public InputField InputQuizTxt;
    public InputField InputAnsTxt;
    public Text quizTxt;
    public Text ansTxt;

    //クイズと解答の保持テスト
    static List<string> quiz = new List<string>();
    static List<string> ans  = new List<string>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SaveText()
    {
        quiz.Add(InputQuizTxt.text);
        ans.Add(InputAnsTxt.text);
        quizTxt.text = "";
        ansTxt.text = "";
    }
}
