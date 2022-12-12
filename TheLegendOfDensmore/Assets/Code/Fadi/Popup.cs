using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Popup : MonoBehaviour
{
    // Start is called before the first frame update
	float t = 255;
	float prev_t;
	public string popup_text;
	
    void Start()
    {
		Destroy(gameObject,5);
    }

    // Update is called once per frame
    void Update()
    {
		gameObject.GetComponent<TMP_Text>().text = popup_text;
		prev_t = t;
		t -= Time.deltaTime*50;
		if(t > prev_t){
		t = 0;
		}
		gameObject.GetComponent<TMP_Text>().color = new Color32(255, 255, 255, (byte)((int)t));
        transform.Translate(Vector2.up* Time.deltaTime*25);
    }
}
