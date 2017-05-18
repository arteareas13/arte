using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LikeButton : MonoBehaviour {

    public Sprite likedButton;
    public Sprite likeButton;
    public GameObject likeListUI;
    public likeList likeListScript;
    public Stage3_6_GameController controller;
    private Stage3_5_tree_coco tree;

    void Start()
    {
        tree = GetComponentInParent<Stage3_5_tree_coco>();
        transform.parent.gameObject.SetActive(false);
        if (GameObject.Find("Stage3_6_GameController"))
        {
            controller = GameObject.Find("Stage3_6_GameController").GetComponent<Stage3_6_GameController>();
            Debug.Log("Find controller");
        }
    }
    	
    void OnMouseDown()
    {
        if (tree.like)
        {
            GetComponent<SpriteRenderer>().sprite = likeButton;
            tree.like = false;
            if (tree.ID == 1)
            {
                Stage3_Controller._stage3_q12_1 = false;
                showHeart(0);
            }
            else if (tree.ID == 2)
            {
                Stage3_Controller._stage3_q12_2 = false;
                showHeart(1);
            }
            else if (tree.ID == 3)
            {
                Stage3_Controller._stage3_q12_3 = false;
                showHeart(2);
            }
        }
        else {
            GetComponent<SpriteRenderer>().sprite = likedButton;
            tree.like = true;
            if (tree.ID == 1)
            {
                Stage3_Controller._stage3_q12_1 = true;
                showHeart(0);
            }
            else if (tree.ID == 2)
            {
                Stage3_Controller._stage3_q12_2 = true;
                showHeart(1);
            }
            else if (tree.ID == 3)
            {
                Stage3_Controller._stage3_q12_3 = true;
                showHeart(2);
            }
        }

        if (controller != null)
        {
            controller.activatePortal();
        } else
        {
            Debug.Log("not working");
        }
    }
    
    void showHeart(int i)
    {
        likeListUI = GameObject.Find("quest12_likelist(Clone)");
        likeListScript = likeListUI.GetComponent<likeList>();
        if (tree.like && likeListUI != null)
        {
            likeListScript.heart[i].GetComponent<Image>().enabled = true;
        } else if(!tree.like && likeListUI != null)
        {
            likeListScript.heart[i].GetComponent<Image>().enabled = false;
        }
    }
}
