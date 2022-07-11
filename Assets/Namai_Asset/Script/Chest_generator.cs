
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Chest_generator : MonoBehaviour
{
    /*�󔠂�錾*/
    public GameObject Prefab_open_chest;
    public GameObject first_chest;
    public GameObject first_chest1;
    public GameObject first_chest2;
    public GameObject first_chest3;
    public GameObject first_chest4;
    public GameObject first_chest5;
   

    /*�J�ڂ���p�l����錾*/
    public GameObject GetTreasure_Panel;
    public GameObject Name_Object = null;

    public GameObject TreasureList_Panel;
    
 
    /*�󔠂��J�����Ƃ���SE��錾*/
    public AudioClip chest_open_SE;
    AudioSource aud;
    //int Tap_num = 0;

    /*�󕨂�錾*/
    public GameObject Burger_prefab;
    public GameObject Croissant_prefab;
    public GameObject Pineapple_prefab;
    public GameObject Pizza_prefab;
    public GameObject Sushi_prefab;
    public GameObject Watermelon_prefab;

    /*�ǉ�*/
    public GameObject t1Button;
    public GameObject t2Button;
    public GameObject t3Button;
    public GameObject t4Button;
    public GameObject t5Button;
    public GameObject t6Button;
    public GameObject GametoListButton;

    public Sprite BurgerImg;
    public Sprite CroissantImg;
    public Sprite PineappleImg;
    public Sprite PizzaImg;
    public Sprite SushiImg;
    public Sprite WatermelonImg;


    //�@�^���@�@ �z��̖��O �ǉ�
    GameObject[] TreasureBox;
    GameObject[] ChestBox;
    int[] TapBox;
    string[] NameBox;

    Sprite[] ImgBox;
    GameObject[] ButtonBox;



    int id = 0;
    int tre_id;
    Vector3 Chest_Pos;
    Vector3 Tre_Pos;


    void Start()
    {
        /*�����̏���*/
        this.aud = GetComponent<AudioSource>();

        /*������ׂ��łȂ��p�l�����\��*/
        GetTreasure_Panel.SetActive(false);
        TreasureList_Panel.SetActive(false);

        // �z��̖��O�@�@�@�@�^���@�@�@�@�@�������Q�[���I�u�W�F�N�g �ǉ�
        TreasureBox = new GameObject[] { Burger_prefab, Croissant_prefab, Pineapple_prefab, Pizza_prefab, Sushi_prefab, Watermelon_prefab };

        ChestBox = new GameObject[] { first_chest, first_chest1, first_chest2, first_chest3, first_chest4, first_chest5 };

        TapBox = new int[] { 0, 0, 0, 0, 0, 0 };

        NameBox = new string[]{ "ハンバーガー", "クロワッサン", "パイナップル", "ピザ", "寿司", "スイカ" };

        ImgBox = new Sprite[] { BurgerImg, CroissantImg, PineappleImg, PizzaImg, SushiImg, WatermelonImg };

        ButtonBox = new GameObject[] { t1Button, t2Button, t3Button, t4Button, t5Button, t6Button };

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            id = 0;

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                foreach (GameObject g in ChestBox)
                {
                    id += 1;
                    if (hit.transform.name == g.name)
                    {
                        id -= 1;

                        Chest_Pos = new Vector3(g.transform.position.x, g.transform.position.y, g.transform.position.z);
                        Tre_Pos = new Vector3(g.transform.position.x, g.transform.position.y + 0.3f, g.transform.position.z - 0.1f);
                        //Debug.Log(Chest_Pos);//�����󔠂̈ʒu���擾
                        Instantiate(Prefab_open_chest, Chest_Pos, Quaternion.Euler(-90f, 0.0f, -90f));
                        //�����󔠂̈ʒu�ɊJ�����󔠂𐶐�����
                        
                        this.aud.PlayOneShot(this.chest_open_SE);
                        
                        ChestBox[id].SetActive(false);
                        TapBox[id] += 1;
                        

                        tre_id = id;
                        //Debug.Log(tre_id);
                        Invoke(nameof(GetShowMethod), 0.8f);

                    }
                }
            }
        }
    }
    

    void GetShowMethod()
    {
        GetTreasure_Panel.SetActive(true);//�󕨂��Q�b�g������ʂ�\��������
        GametoListButton.SetActive(false);
        Instantiate(TreasureBox[tre_id], Tre_Pos, Quaternion.identity);
        //Debug.Log(tre_id);
        Text Name_Text = Name_Object.GetComponent<Text>();
        Name_Text.text = "宝物: " + NameBox[tre_id];
        ButtonBox[tre_id].GetComponent<Image>().sprite = ImgBox[tre_id];

    }

    public void ToListButtonDown()
    {
        //Debug.Log("�{�^��1��������܂���");
        GetTreasure_Panel.SetActive(false);
        TreasureList_Panel.SetActive(true);
        
        //ShowListMethod();
    }
    
    public void ToBackButton_gDown()
    {
        //Debug.Log("�{�^��2��������܂���");
        GetTreasure_Panel.SetActive(false);
        GametoListButton.SetActive(true);
    }

    public void ToBackButton_tDown()
    {
        //Debug.Log("�{�^��3��������܂���");
        TreasureList_Panel.SetActive(false);
        GametoListButton.SetActive(true);

    }

    public void GametoListBottonDown()
    {
        //Debug.Log("�{�^��4��������܂���"); 
        TreasureList_Panel.SetActive(true);
        GametoListButton.SetActive(false);
    }
}

/*
 ���������������
    //open_chest���A�N�e�B�u�ɂ����󔠂̑O�ɒu����悤�ɂ���
    //getPanel��\���������ƕ󕨂�󔠂̑O�ɒu����悤�ɂ���
�@�@//get�����g���W���[��Treasure���X�g�p�l���ɕ\���ł���悤�ɂ���
 */