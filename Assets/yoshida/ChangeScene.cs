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

    public void FindTreasure()
    {   
        SceneManager.LoadScene("FindTreasure");
    }

    // Update is called once per frame
    void Update()
    {
    }
}
