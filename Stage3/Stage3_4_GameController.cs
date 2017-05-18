﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage3_4_GameController : MonoBehaviour {
    private GameObject player;
    private Transform start_pos;
    private Item_Controller ic;
    private Text_Importer aa;
	public GameObject ivon_textbox, coco_textbox;

    //public bool quest1_start1;
    public bool quest1_start2;
    //public bool quest1_processing;
    //public bool quest1_complete;
    public bool quest2_start1;
    public bool quest2_start2;

	private bool a1a1 = false;
	private bool a1a2 = false;
	private bool a2a1 = false;
	private bool a1a3 = false;
	private bool a1a4 = false;
    private bool a1a5 = false;
    private bool a1a6 = false;
    private bool a7 = false;
	private bool a8 = false;
	private bool a8a1, a8a2, a8a3, a8a4;
    private bool q9 = false;

    public GameObject quest1_gaugePrefab;
    public GameObject quest1_gauge;
    private Vector3 tempPos;
    public GameObject quest2_ball1;
    public GameObject quest2_ball2;
    public Transform _Ivon_Position;
    public GameObject portal3_5;
	public GameObject portalEnd;

    void Awake()
    {
        player = GameObject.Find("Player");
        start_pos = GameObject.Find("Start_Pos").transform;
        player.transform.position = start_pos.position;
		_Ivon_Position = GameObject.FindWithTag("NPC").transform;
        ic = GameObject.FindWithTag("Item_Canvas").GetComponent<Item_Controller>();
    }

	void Start(){
		aa = GameObject.FindWithTag("Dialogue").GetComponent<Text_Importer>();
		if (Stage3_Controller._stage3_q5 && !Stage3_Controller._stage3_q6) {
			//집에서 나옴. 달리기미션 not clear
			//aa = GameObject.FindWithTag("Dialogue").GetComponent<Text_Importer>();
			aa.currLineArr[1] += 2;//이본 다음대사 넘김
			//quest1_start1 = true;
		}
	}
    
    void OnTriggerEnter2D()
    {
        if (Stage3_Controller._stage3_q5 && !Stage3_Controller._stage3_q6)
        {
            aa.NPC_Say_yeah(name); //이본대사 : 답답했지? 뛰어놀자
            ivon_textbox = GameObject.Find("이본_text");
            quest1_start2 = true;
        }

        if (Stage3_Controller._stage3_q6 && !Stage3_Controller._stage3_q7)
        {
            if (quest2_start1 && !ivon_textbox.activeSelf)
            {
                aa.currLineArr[1] += 2;
                aa.NPC_Say_yeah(name); // 공놀이 시작
                Stage3_Controller._stage3_q7 = true;
                quest2_start1 = false;
            }
        }

        if (Stage3_Controller._stage3_q8 && !Stage3_Controller._stage3_q9)
        {
            a1a3 = checkBall(a1a3);
            
            if (a1a3 && !a1a4)
            {
                aa.currLineArr[1] += 2;//이본 다음대사 넘김
                aa.NPC_Say_yeah("이본"); //잘했어 한번 더 물ㅓ와라
                a1a4 = true;
            }
        }

        if (Stage3_Controller._stage3_q9 && !Stage3_Controller._stage3_q10)
        {
            a1a6 = checkBall(a1a6);

            if (!a1a5 && a1a6)
            {
                aa.currLineArr[1] += 2;//이본 다음대사 넘김
                aa.NPC_Say_yeah("이본"); // 공놀이 끝
                quest1_gauge.SetActive(true);
                a1a5 = true;
            }
        }

		if (Stage3_Controller._stage3_q10 && !Stage3_Controller._stage3_q11)
        {
            if (!a7)
            {
                aa.currLineArr[1] += 2;//이본 다음대사 넘김
                aa.NPC_Say_yeah("이본");//코코 착하지 마음껏 놀았니? (가서 다른 강아지들이랑 놀고오렴)
                portal3_5.GetComponent<BoxCollider2D>().enabled = true;
                a7 = true;
            }
        }

		if (Stage3_Controller._stage3_q13) {
			a8 = true;
		}
    }

	void Update () {
		if (Stage3_Controller._stage3_q5 && !Stage3_Controller._stage3_q6)
        {
			Q6_Running_Start (); //게이지 생김.
        }

		if (Stage3_Controller._stage3_q6 && !Stage3_Controller._stage3_q7)
        {
			Q7_Running (); 	//게이지 줄이고, 코코 부름.
        }

		if (Stage3_Controller._stage3_q7 && !Stage3_Controller._stage3_q8) {
			Q8_BallPlayStart ();
		}

		if (Stage3_Controller._stage3_q8 && !Stage3_Controller._stage3_q9) {
			Q9_GetABall_Onemore ();
		}

        if (Stage3_Controller._stage3_q9 && !Stage3_Controller._stage3_q10)
        {
            Q10_Running_Finish();
        }

		if (Stage3_Controller._stage3_q13 && a8) {
			//aa.Import (15); // temp code
			Q13_Talk ();
		}
    }


	void Q6_Running_Start(){
		if (quest1_start2 && !ivon_textbox.activeSelf)
		{
			quest1_gauge = Instantiate(quest1_gaugePrefab, Vector3.zero, Quaternion.identity) as GameObject;
			quest1_gauge.transform.SetParent(GameObject.FindWithTag("Item_Canvas").transform, false);
			Stage3_Controller._stage3_q6 = true;
			quest1_start2 = false;
			tempPos = player.transform.position;
		}
	}

	void Q7_Running(){
        if (tempPos != player.transform.position)
        {
            quest1_gauge.transform.localScale = new Vector3(quest1_gauge.transform.localScale.x - Vector3.Distance(tempPos, player.transform.position) / 180f, 1, 1);
            tempPos = player.transform.position; // 맵의 가로길이가 30이라고 가정한 수치
        }

        if (quest1_gauge.transform.localScale.x <= 2f / 3f && !a2a1) // 게이지가 2/3가 되면
		{
			quest2_start1 = true;
			aa.currLineArr[1] += 2;
			aa.NPC_Say_yeah("이본"); // 코코 부름
			a2a1 = true;
		}
	}

	void Q8_BallPlayStart(){
		
		if (!a1a1 && ivon_textbox.activeSelf) { //click해서 대사침.
			a1a2 = true;
			a1a1 = true;
		}

		if (a1a2 && !ivon_textbox.activeSelf) {//윗 대사 종료
			//공던짐.
			_Ivon_Position = GameObject.FindWithTag("NPC").transform;
			if (Stage3_Controller._stage3_q3_1) {//1,2 or 1,3
				GameObject aa = (GameObject)Instantiate(Resources.Load("Prefabs/Hokyun/ball1"));
				aa.transform.position = _Ivon_Position.position;
				aa.GetComponent<Ball_popup> ().enabled = true;
                Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), aa.GetComponent<Collider2D>(), false);
            } else {//2,3
				GameObject aa = (GameObject)Instantiate(Resources.Load("Prefabs/Hokyun/ball2"));
				aa.transform.position = _Ivon_Position.position;
				aa.GetComponent<Ball_popup> ().enabled = true;
                Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), aa.GetComponent<Collider2D>(), false);
            }
			a1a2 = false;
			Stage3_Controller._stage3_q8 = true;
            quest1_gauge.SetActive(false); // running pause
        }
        
    }

    void Q9_GetABall_Onemore(){
        
		if (a1a4 && !ivon_textbox.activeSelf) {
			if (Stage3_Controller._stage3_q3_1 && Stage3_Controller._stage3_q3_2) {
				GameObject aa = (GameObject)Instantiate(Resources.Load("Prefabs/Hokyun/ball2"));
				aa.transform.position = _Ivon_Position.position;
				aa.GetComponent<Ball_popup> ().enabled = true;
                Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), aa.GetComponent<Collider2D>(), false);
            } else {
				GameObject aa = (GameObject)Instantiate(Resources.Load("Prefabs/Hokyun/ball3"));
				aa.transform.position = _Ivon_Position.position;
				aa.GetComponent<Ball_popup> ().enabled = true;
                Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), aa.GetComponent<Collider2D>(), false);
            }
            a1a4 = false;
            Stage3_Controller._stage3_q9 = true;
            quest1_gauge.SetActive(false); // running pause
        }
        
    }

    void Q10_Running_Finish()
    {
        if (tempPos != player.transform.position)
        {
            quest1_gauge.transform.localScale = new Vector3(quest1_gauge.transform.localScale.x - Vector3.Distance(tempPos, player.transform.position) / 180f, 1, 1);
            tempPos = player.transform.position; // 맵의 가로길이가 30이라고 가정한 수치
        }
        if (quest1_gauge.transform.localScale.x <= 0)
        {
            Destroy(quest1_gauge); // 게이지 다달면 끝
            Stage3_Controller._stage3_q10 = true;
        }
    }

	void Q13_Talk(){
		if (!a8a1) {
			aa.currLineArr[1] += 2; //이본 다음대사 넘김
			aa.NPC_Say_yeah("이본");
			Debug.Log ("a8a1");
			ivon_textbox = GameObject.Find ("이본_text");
			a8a1 = true;
		}

		if (a8a1 && !a8a2 && !ivon_textbox.activeSelf) {
			aa.currLineArr [0] = 10; //코코 다음대사 치게함.
			aa.NPC_Say_yeah ("코코"); // heart (5)
			Debug.Log ("a8a2");
			coco_textbox = GameObject.Find ("코코_text");
			a8a2 = true;
		}

		if (a8a2 && !a8a3 && !coco_textbox.activeSelf) {
			aa.currLineArr[1] += 2; //이본 다음대사 넘김
			aa.NPC_Say_yeah("이본");
			Debug.Log ("a8a3");
			ivon_textbox = GameObject.Find ("이본_text");
			a8a3 = true;
		}

		if (a8a3 && !a8a4 && !ivon_textbox.activeSelf) {
			aa.currLineArr [0] = 12; //코코 다음대사 치게함.
			aa.NPC_Say_yeah ("코코"); // mung! (6)
			Debug.Log ("a8a4");
			coco_textbox = GameObject.Find ("코코_text");
			a8a4 = true;
		}

		if (a8a4 && !coco_textbox.activeSelf) {
			Debug.Log ("a8a5");
			portal3_5.GetComponent<BoxCollider2D> ().enabled = false;
			portalEnd.GetComponent<BoxCollider2D> ().enabled = true;
			_Ivon_Position.gameObject.GetComponent<SpriteRenderer> ().enabled = false;
			a8 = false;
		}
			
	}

    bool checkBall(bool a)
    {
        if (!a)
        {
            for (int i = 0; i < ic._item_list.Length; i++)
            {
                if (ic._item_name_list[i] == "ball1") 
                {
                    a = true;
                    Use_Item("ball1");
                    return a;
                } else if (ic._item_name_list[i] == "ball2")
                {
                    a = true;
                    Use_Item("ball2");
                    return a;
                } else if(ic._item_name_list[i] == "ball3")
                {
                    a = true;
                    Use_Item("ball3");
                    return a;
                }
            }
        }
        return a;
    }

    void Use_Item(string name)
    {
        for (int i = 0; i < 5; i++)
        {
            if (ic._item_name_list[i] == name)
            {
                ic._item_name_list[i] = "";
                ic._usable_item[i] = false;
                ic._the_number_of_items[i] = 0;
                ic._interaction_object[i] = "";
                ic._consumable[i] = false;
                ic._item_list[i].GetComponent<Image>().color = new Color(255, 255, 255, 0);
                ic._item_list[i].transform.parent.GetComponentInChildren<Text>().color = new Color(255, 255, 255, 0);
            }
        }
    }

}
