using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toys : MonoBehaviour {

	public int _this_num;
	public GameObject _player;
	public bool _pickable = false;
	private Item_Controller i_c;

	void Awake(){
		_player = GameObject.FindWithTag ("Player");
		i_c = GameObject.Find ("Item_Canvas").GetComponent<Item_Controller>();
		//멍멍이와의 충돌만 무시함.
		Physics2D.IgnoreCollision (_player.GetComponent<Collider2D> (), GetComponent<Collider2D> (), true);
	}
		

	void OnMouseDown(){
		if (_pickable) {
			if (i_c.Get_Item_Auto (_this_num, GetComponent<SpriteRenderer> ().sprite)) {
				//i_c.Get_Item_Auto ("장난감" + _this_num, GetComponent<SpriteRenderer> ().sprite, true, "Air", true);
				if (_this_num == 11) {
					Stage3_Controller._stage3_q3_1 = true;
				} else if (_this_num == 12) {
					Stage3_Controller._stage3_q3_2 = true;
				} else if (_this_num == 13){
					Stage3_Controller._stage3_q3_3 = true;
				}
				Destroy (this.gameObject);
			}
		}
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (i_c.Get_Item_Auto(11, GetComponent<SpriteRenderer>().sprite))
            {
                if (_this_num == 1)
                {
                    Stage3_Controller._stage3_q3_1 = true;
                }
                else if (_this_num == 2)
                {
                    Stage3_Controller._stage3_q3_2 = true;
                }
                else {
                    Stage3_Controller._stage3_q3_3 = true;
                }
                Destroy(this.gameObject);
            }
        }
    }
}
