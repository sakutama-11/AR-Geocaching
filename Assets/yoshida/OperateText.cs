using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class OperateText: MonoBehaviour
{
    //public Canvas canvas;
    public Text text;
    private bool isCorrect = InputAnswer.isGetText;
    private int count = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        text.enabled = false;
    }
    void DelayMethod()
    {
        Debug.Log("DelayMethod for Correct");
    }

    void TextManeger()
    {
        if (isCorrect)
        {
            if (count == 1)
            {
                Invoke("DelayMethod", 3);

                count = 0;
            }
            text.enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        TextManeger();
    }
}
