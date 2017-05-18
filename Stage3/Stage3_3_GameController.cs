using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage3_3_GameController : MonoBehaviour {

	private bool a1 = false;
	private bool a2 = false;
	private GameObject player;
    private GameObject npc;
	public GameObject _ivon_textbox;
	private Transform start_pos;
    private Item_Controller ic;
    private Text_Importer aa;

	public Transform _ivon;
    public GameObject portalto3_4;
	//private Transform regen_pos;
	void Awake(){
		player = GameObject.Find ("Player");
        npc = GameObject.FindWithTag("NPC");
		start_pos = GameObject.Find ("Start_Pos").transform;
		player.transform.position = start_pos.position;
        ic = GameObject.FindWithTag("Item_Canvas").GetComponent<Item_Controller>();
        aa = GameObject.FindWithTag("Dialogue").GetComponent<Text_Importer>();
        //regen_pos = GameObject.Find ("Regen_Pos").transform;
    }

    void OnTriggerEnter2D()
    {
        if (Stage3_Controller._stage3_q1 && !Stage3_Controller._stage3_q2)
        {
            Q2_start_getaBall();
        }

        if (Stage3_Controller._stage3_q2 && !Stage3_Controller._stage3_q3)
        {
            if ((Stage3_Controller._stage3_q3_1 && Stage3_Controller._stage3_q3_2) ||
                   (Stage3_Controller._stage3_q3_1 && Stage3_Controller._stage3_q3_3) ||
                   (Stage3_Controller._stage3_q3_2 && Stage3_Controller._stage3_q3_3))
            {
                Q4_start_getaBag();
            }
        }

        if (Stage3_Controller._stage3_q3 && !Stage3_Controller._stage3_q4)
        {
            if (Stage3_Controller._stage3_q4_1 && !Stage3_Controller._stage3_q5)
            {
                Q5_start_goOut();
            }
        }
    }

	void Q2_start_getaBall(){
        aa.currLineArr[1] += 2;
        aa.NPC_Say_yeah(name);
        Stage3_Controller._stage3_q2 = true;
    }

	void Q4_start_getaBag(){
        Use_Item("ball1");
        Use_Item("ball2");
        Use_Item("ball3");//공주워온거지움
        aa.currLineArr[1] += 2;//이본 다음대사 치게함.
        aa.NPC_Say_yeah("이본");
        _ivon_textbox = GameObject.Find("이본_text");
        Stage3_Controller._stage3_q3 = true;
	}

    void Q5_start_goOut()
    {
        Use_Item("봉투");
        aa.currLineArr[1] += 2;//이본 다음대사 치게함.
        aa.NPC_Say_yeah("이본");
        Stage3_Controller._stage3_q5 = true;
        portalto3_4.GetComponent<BoxCollider2D>().enabled = true;
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
