using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bag : MonoBehaviour {
	
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
                Stage3_Controller._stage3_q4_1 = true;
        }
    }
}
