﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save_Script : MonoBehaviour {

	public static bool[] S1 = new bool[10];
	public static bool[] S2 = new bool[25];
	public static int[] S2_intArr = new int[3];
	public static bool[] S3;
	public static Item_Controller _ic_for_Save;
	public static Text_Importer _ti_for_Save;

	public static void Save_Item_Info(){ //아이템을 먹거나 사용할 때 호출

		_ic_for_Save = GameObject.FindWithTag ("Item_Canvas").GetComponent<Item_Controller> ();

		PlayerPrefsX.SetStringArray ("IC_nameList", _ic_for_Save._item_name_list);
		PlayerPrefsX.SetBoolArray ("Usable_item", _ic_for_Save._usable_item);
		PlayerPrefsX.SetIntArray ("NumOfItem", _ic_for_Save._the_number_of_items);
		PlayerPrefsX.SetStringArray ("Interaction", _ic_for_Save._interaction_object);
		PlayerPrefsX.SetBoolArray ("Consumable", _ic_for_Save._consumable);
	}
		
	public static void Save_Dialogue_Info(){ //대사가 끝나면 호출
		
		if (GameObject.FindWithTag ("Dialogue")) {
			_ti_for_Save = GameObject.FindWithTag ("Dialogue").GetComponent<Text_Importer> ();
		}
		if (_ti_for_Save._textfile != null) {
			PlayerPrefsX.SetIntArray ("CurrArr", _ti_for_Save.currLineArr);
		}

	}

	public static void Save_Scene_Info(){ //씬을 넘어가면 호출
		//우선 기존방식 유지
	}

	public static void Save_Quest_Info(){ //퀘스트를 끝내면(bool변경될 때 마다)호출
		Save_S1 ();
		Save_S2 ();
		PlayerPrefsX.SetBoolArray ("Stage1_Quest", S1);
		PlayerPrefsX.SetBoolArray ("Stage2_Quest", S2);
		PlayerPrefsX.SetIntArray ("Stage2_Quest_INT", S2_intArr);
	}

	public static void Save_S1(){
		//S1 = new bool[10];
		S1 = Stage1_Controller._Stage1_Quest;
		//S1 [0] = Stage1_Controller._stage1_q1;
		//S1 [1] = Stage1_Controller._stage1_q2;
		//S1 [2] = Stage1_Controller._stage1_q3;
		//S1 [3] = Stage1_Controller._stage1_q4;
		//S1 [4] = Stage1_Controller._stage1_q5;
		//S1 [5] = Stage1_Controller._stage1_q6;
		//S1 [6] = Stage1_Controller._stage1_q7;
		//S1 [7] = Stage1_Controller._stage1_q8;
		//S1 [8] = Stage1_Controller._stage1_q9;
		//S1 [9] = Stage1_Controller._stage1_q10;
	}

	public static void Save_S2(){
		//S2 = new bool[25];
		//S2_intArr = new int[3];

		S2 = Stage2_Controller._Stage2_Quest;
		S2_intArr = Stage2_Controller._Stage2_Quest_intArr;
		//		S2 [0] = Stage2_Controller._stage2_q1;
		//		S2 [1] = Stage2_Controller._stage2_q2;
		//		S2 [2] = Stage2_Controller._stage2_q3;
		//		S2 [3] = Stage2_Controller._stage2_q4;
		//		S2 [4] = Stage2_Controller._stage2_q5;
		//		S2 [5] = Stage2_Controller._stage2_q6;
		//		S2 [6] = Stage2_Controller._stage2_q7;
		//		S2 [7] = Stage2_Controller._stage2_q8;
		//		S2 [8] = Stage2_Controller._stage2_q9;
		//		S2 [9] = Stage2_Controller._stage2_q10;
		//		S2 [10] = Stage2_Controller._stage2_q11;
		//		S2 [11] = Stage2_Controller._stage2_q12;
		//		S2 [12] = Stage2_Controller._stage2_q12_1;
		//		S2 [13] = Stage2_Controller._stage2_q13;
		//		S2 [14] = Stage2_Controller._stage2_q14;
		//		S2 [15] = Stage2_Controller._stage2_q15;
		//		S2 [16] = Stage2_Controller._stage2_q16;
		//		S2 [17] = Stage2_Controller._stage2_q17;
		//		S2 [18] = Stage2_Controller._stage2_q18;
		//		S2 [19] = Stage2_Controller._stage2_q19;
	}

	public static void Save_S3(){
		S3 = new bool[10];
		//진행중
	}
}
