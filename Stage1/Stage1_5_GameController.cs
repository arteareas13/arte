﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1_5_GameController : MonoBehaviour {

	public BoxCollider2D[] transparent_walls;

	private Transform start_pos;
	private Transform regen_pos;
	private GameObject player;
	public Outline[] o_l;
	public Mirror_Socket_Controller[] msc;
	public GameObject[] xx;

	//public static bool stage1_5_mirror_or_not_1 = false;
	//public static bool stage1_5_mirror_or_not_2 = false;
	//public static bool stage1_5_mirror_or_not_3 = false;

	void Awake(){
		player = GameObject.Find ("Player");
		start_pos = GameObject.Find ("Start_Pos").transform;
		regen_pos = GameObject.Find ("Regen_Pos").transform;
//		msc = GameObject.Find ("Mirror_Socket").GetComponent<Mirror_Socket_Controller> ();
//		o_l = GameObject.Find ("Mirror_Socket").GetComponent<Outline> ();
//		o_l.used_or_not_for_retry = true;

		for(int i = 0 ; i < 1 ; i ++){
			o_l [i].used_or_not_for_retry = false;
		}

		player.transform.position = start_pos.position;
	}

	void Start(){
		if (GetComponent<Load_data> ()._where_are_you_from == 10) {
			player.transform.position = regen_pos.position;
		}

		if (Stage1_Controller._Stage1_Quest[6]) {
			xx[0].SetActive(false);
			transparent_walls[0].enabled = false;
			msc [0].mirror_in_ornot = false;
			Destroy (msc [0].gameObject);
		}
//		if (Stage1_Controller._Stage1_Quest[7]) {
//			xx[1].SetActive(false);
//			transparent_walls[1].enabled = false;
//			msc [1].mirror_in_ornot = false;
//			Destroy (msc [1].gameObject);
//		}
//		if (Stage1_Controller._Stage1_Quest[8]){
//			xx[2].SetActive(false);
//			transparent_walls[2].enabled = false;
//			msc [2].mirror_in_ornot = false;
//			Destroy (msc [2].gameObject);
//		}

	}


	void LateUpdate(){
		//static으로 고정필요

		if (msc[0].mirror_in_ornot) {//거울이 있을 때
			//xx[0].SetActive(false);
			Mirror_Effect_Off(xx[0].GetComponent<SpriteRenderer>());
			transparent_walls[0].enabled = false;
			msc [0].mirror_in_ornot = false;
			Destroy (msc [0].gameObject);
			Stage1_Controller._Stage1_Quest[6] = true;
			Save_Script.Save_Quest_Info ();
		}
//		if (msc[1].mirror_in_ornot) {//거울이 있을 때
//			//xx[1].SetActive(false);
//			Mirror_Effect_Off(xx[1].GetComponent<SpriteRenderer>());
//			transparent_walls[1].enabled = false;
//			msc [1].mirror_in_ornot = false;
//			Destroy (msc [1].gameObject);
//			Stage1_Controller._Stage1_Quest[7] = true;
//		}
//		if (msc[2].mirror_in_ornot) {//거울이 있을 때
//			//xx[2].SetActive(false);
//			Mirror_Effect_Off(xx[2].GetComponent<SpriteRenderer>());
//			transparent_walls[2].enabled = false;
//			msc [2].mirror_in_ornot = false;
//			Destroy (msc [2].gameObject);
//			Stage1_Controller._Stage1_Quest[8] = true;
//		}
	}

	IEnumerator Mirror_Effect_Off(SpriteRenderer a){
		//if (a.size.x > 1f) {
		float i = 1.91f;
		while (true) {
			i -= 0.08f;
			a.size = new Vector2 (i, 3.74f);
			if (i < 0) {
				a.size = new Vector2 (0f, 3.74f);
				break;
			}
			yield return null;
		}
		//}
	}
}
