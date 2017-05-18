﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage3_5_GameController : MonoBehaviour {

    protected GameObject player;
    protected Transform start_pos;
	protected Transform end_pos;
    protected Item_Controller ic;
    protected Text_Importer ti;
	public GameObject portal3_4, portal3_6;

    public Sprite npcTemp;
    public bool usable;
    public bool consumable;

    public GameObject[] trees;
    protected GameObject[] likeButton;

    protected void Awake()
    {
        player = GameObject.Find("Player");
        start_pos = GameObject.Find("Start_Pos").transform;
		end_pos = GameObject.Find ("End_Pos").transform;
        player.transform.position = start_pos.position;
        ic = GameObject.FindWithTag("Item_Canvas").GetComponent<Item_Controller>();
        ti = GameObject.FindWithTag("Dialogue").GetComponent<Text_Importer>();
        trees = GameObject.FindGameObjectsWithTag("Tree");
        likeButton = GameObject.FindGameObjectsWithTag("likeButton");
    }

    void Start() {
		if (Stage3_Controller.sceneIndex > SceneManager.GetActiveScene ().buildIndex) {
			player.transform.position = end_pos.position;
		}
		Stage3_Controller.sceneIndex = SceneManager.GetActiveScene ().buildIndex;
			
        if (!Stage3_Controller._stage3_q11)
        {
			//ic.Get_Item_Auto (5, npcTemp); //temp code
            //ti.Import(15);
        }

        if (Stage3_Controller._stage3_q12)
        {
            for (int i = 0; i < likeButton.Length; i++)
            {
                likeButton[i].GetComponent<LikeButton>().enabled = false; // like 버튼 비활성화
            }
        }

		if (Stage3_Controller._stage3_q13) {
			portal3_4.GetComponent<BoxCollider2D> ().enabled = true;
			portal3_6.GetComponent<BoxCollider2D> ().enabled = false;
		}

    }
	
	
}
