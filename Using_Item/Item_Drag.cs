using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Item_Drag : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler{

	private Image item_img;
	private Item_Controller ic;
	private GameObject item_Info;

	public int numbering;
	public TurnOnOffItemList onoffList;
	public AudioSource _click_sound;


	private bool drag_ornot = false;
	void Awake(){
		ic = GameObject.FindWithTag ("Item_Canvas").GetComponent<Item_Controller> ();
		item_Info = GameObject.Find ("Item_Info");
		item_img = GetComponent<Image> ();
	}

	void Start(){
		item_Info.SetActive (false);
	}

	public virtual void OnDrag(PointerEventData ped){
		Vector2 pos;
		if (RectTransformUtility.ScreenPointToLocalPointInRectangle (item_img.rectTransform, ped.position, Camera.main, out pos)) {
			item_img.rectTransform.position = ped.position;
		}
		onoffList.OnTime = Time.realtimeSinceStartup;
		if (!drag_ornot) {
			item_Info.SetActive (true);
			item_Info.GetComponentInChildren<Text> ().text = ic._explanations [numbering];
			drag_ornot = true;
		}
	}

	public virtual void OnPointerDown(PointerEventData ped){
		OnDrag (ped);
		onoffList.OnTime = Time.realtimeSinceStartup;
		_click_sound.Play ();
	}


	public virtual void OnPointerUp(PointerEventData ped){

		item_Info.SetActive (false);
		drag_ornot = false;
		_click_sound.Play ();

		Vector2 wp = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Ray2D ray = new Ray2D (wp, Vector2.zero);
		RaycastHit2D hit = Physics2D.Raycast (ray.origin, ray.direction);

		if (hit.collider != null) {
			//tag 비교해서 아이템사용처럼 해야함
			if (hit.collider.tag == ic._interaction_object [numbering]) {
				//print (hit.collider.name);
				Outline aa = hit.collider.gameObject.GetComponent<Outline>();
				aa._item_num = numbering;
				aa.SSDDSSDD();
				//사용되었다면 사용된 상대에 대한 정보 + 그 후 무슨일이 일어날 지?(GameController 외에도)
				ic._now_object_item_used = hit.collider.name;
				ic._to_run_once = true;
			} else {
				
			}
		}

		item_img.rectTransform.anchoredPosition = Vector3.zero;
	}

}
