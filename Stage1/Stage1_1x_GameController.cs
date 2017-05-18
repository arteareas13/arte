﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Stage1_1x_GameController : MonoBehaviour {

	private Transform start_pos;
	private Transform regen_pos;
	private GameObject player;
	private Moving_by_RLbuttons mbr;
	//public Text Player_text;

	void Awake(){
		player = GameObject.Find ("Player");
		mbr = player.GetComponent<Moving_by_RLbuttons> ();
		//Player_text = GameObject.Find ("코코_text").GetComponent<Text> ();
		start_pos = GameObject.Find ("Start_Pos").transform;
		regen_pos = GameObject.Find ("Regen_Pos").transform;
		player.transform.position = start_pos.position;
	}

	void Start(){
		if (GetComponent<Load_data> ()._where_are_you_from == 8) {
			player.transform.position = regen_pos.position;
		} else {
			Text_Importer aa = GameObject.FindWithTag ("Dialogue").GetComponent<Text_Importer> ();
			aa.currLineArr [0] += 2;//코코 다음대사로 넘김
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject == player) {
			//말하고 뒤로 자동으로 움직임?
			mbr.enabled = false;
			StartCoroutine ("Backback");
		}
	}

	IEnumerator Backback(){
		for (int i = 0; i < 30; i++) {
			mbr.Moving_left (-8f);
			yield return null;
		}
		Text_Importer aa = GameObject.FindWithTag ("Dialogue").GetComponent<Text_Importer> ();
		aa.NPC_Say_yeah ("코코");
		mbr.enabled = true;
	}
}
