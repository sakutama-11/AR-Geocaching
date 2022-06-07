using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void ChangeSceneCorrect()
    {   
        SceneManager.LoadScene("yoshida_CorrectScene");
        //Debug.Log("CorrectScene");
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(message: "QuizScene" + InputAndBotton.instance.isGetText);
        if(InputAnswer.isGetText == true)
        {
            ChangeSceneCorrect();
        }
    }
}
