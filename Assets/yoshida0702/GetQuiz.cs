using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class GetQuiz : MonoBehaviour
{
    //InputField���C���X�y�N�^�[��Őݒu
    public InputField InputQuizTxt;
    public InputField InputAnsTxt;
    public Text quizTxt;
    public Text ansTxt;

    //�N�C�Y�Ɖ𓚂̕ێ��e�X�g
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
