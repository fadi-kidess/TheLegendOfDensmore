using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextChoice : MonoBehaviour
{
	public GameObject right;
	public GameObject left;
	
	public bool haschosen;
	
	bool finished;
	bool isright;
    // Update is called once per frame
    void Update()
    {
		if(finished)
			return;
        if(Input.GetKeyDown(KeyCode.RightArrow) && !haschosen){
			right.SetActive(true);
			left.SetActive(false);
			isright = true;
		}else if(Input.GetKeyDown(KeyCode.LeftArrow) && !haschosen){
			right.SetActive(false);
			left.SetActive(true);
			isright = false;
		}else if(Input.GetKeyDown(KeyCode.Return)  && !haschosen){
			haschosen = true;
			Debug.Log(choice());
			transform.GetChild(0).gameObject.SetActive(false);
		}
    }
	
	public int choice(){
		if(!haschosen){
			return 0;
		}
		if(!isright){
			return 1;
		}else{
			return 2;
		}
	}
	public void reset(){
		transform.GetChild(0).gameObject.SetActive(true);
		haschosen = false;
		isright = false;
		right.SetActive(false);
		left.SetActive(true);
		finished = false;
	}
	public void deactivate(){
		transform.GetChild(0).gameObject.SetActive(false);
		finished = true;
	}
}
