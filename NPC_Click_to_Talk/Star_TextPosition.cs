﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star_TextPosition : MonoBehaviour {

	RectTransform s;

	Item_Controller _ic;
	TurnOnOffItemList itemlist;

	public RectTransform Star_pos;

	void Awake () {
		s = GetComponent<RectTransform> ();
	}

	void OnEnable(){
		_ic = GameObject.FindWithTag ("Item_Canvas").GetComponent<Item_Controller> ();
		itemlist = _ic.GetComponentInChildren<TurnOnOffItemList> ();
		for (int i = 0; i < _ic._item_list.Length; i++) {
			if (_ic._item_name_list [i] == "별감") {
				Star_pos = GameObject.Find ("Item_button_" + i).GetComponent<RectTransform> ();
			}
		}
	}

	void Update () {
		s.position = new Vector3( Star_pos.position.x - 30, Star_pos.position.y, Star_pos.position.z);
		itemlist.OnTime = Time.realtimeSinceStartup;
	}
}
