﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Trigger : MonoBehaviour {

    private Text_Importer ti;
    private Stage3_3_GameController gc;

    // Use this for initialization
	void Start () {
		ti = GameObject.FindWithTag("Dialogue").GetComponent<Text_Importer>();
        gc = GameObject.Find("Stage3_3_GameController").GetComponent<Stage3_3_GameController>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D()
    {
        if (!Stage3_Controller._stage3_q2)
        {
            ti.NPC_Say_yeah(name);
            Stage3_Controller._stage3_q2 = true;
        }
        //enabled = false;
    }
}
