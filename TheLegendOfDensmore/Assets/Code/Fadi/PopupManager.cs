using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupManager : MonoBehaviour
{
    // Start is called before the first frame update
	public GameObject popup;
    void Start()
    {
        create("HELLOOO");
    }

    
	void create(string text){
		GameObject p = Instantiate(popup);
		p.GetComponent<RectTransform>().anchoredPosition = popup.GetComponent<RectTransform>().anchoredPosition;
		p.transform.parent = gameObject.transform;
		p.SetActive(true);
		p.GetComponent<Popup>().popup_text = text;
	
	}
}
