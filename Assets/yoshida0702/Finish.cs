using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Finish : MonoBehaviour
{
    public Text txtSave;
    public GameObject HomeButton;
    public GameObject FinishButton;
    // Start is called before the first frame update
    void Start()
    {
        txtSave.enabled = false;
        HomeButton.SetActive(false);
        FinishButton.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }

    //•Û‘¶‚µ‚½‚±‚Æ‚Ì•\Ž¦
    public void DispSave()
    {
        txtSave.enabled = true;
        HomeButton.SetActive(true);
        FinishButton.SetActive(false);
    }
}