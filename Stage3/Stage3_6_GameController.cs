using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage3_6_GameController : Stage3_5_GameController
{
	public GameObject portal;
    
    new void Awake()
    {
        base.Awake();
    }

    void Start()
    {
        activatePortal();
		if (Stage3_Controller._stage3_q13) {
			ti.currLineArr[1] += 2; //이본 다음대사 넘김
			ti.NPC_Say_yeah ("이본"); // Ivon calls Coco
			portal.GetComponent<BoxCollider2D>().enabled = false; // deactivate portal to 3_7
		}

		Debug.Log ("sceneIndex is " + SceneManager.GetActiveScene ().buildIndex);
		if (Stage3_Controller.sceneIndex > SceneManager.GetActiveScene ().buildIndex) {
			player.transform.position = end_pos.position;
		}
		Stage3_Controller.sceneIndex = SceneManager.GetActiveScene ().buildIndex;
    }
    
    public void activatePortal()
    {
        if(Stage3_Controller._stage3_q12_1 && Stage3_Controller._stage3_q12_2 && Stage3_Controller._stage3_q12_3)
        {
            portal.GetComponent<BoxCollider2D>().enabled = true;
            Stage3_Controller._stage3_q12 = true;
            Debug.Log("likebutton" + likeButton.Length);
            for (int i = 0; i < likeButton.Length; i++)
                {
                    likeButton[i].GetComponent<PolygonCollider2D>().enabled = false; // like 버튼 비활성화
                }
        } else
        {
            portal.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
