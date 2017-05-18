using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage3_10_basil : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Player") {
			Stage3_Controller._stage3_q13_3 = true;
		}
	}
}
