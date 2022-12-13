using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plasma : MonoBehaviour
{
    // Start is called before the first frame update
	public bool goup;
	public int damage;
    void Start()
    {
         Destroy(gameObject, 1.50f);
		 transform.SetParent(null);
    }

    // Update is called once per frame
    void Update()
    {
		if(!goup){
        	transform.Translate(Vector2.down * Time.deltaTime * 0.5f);
		}else{
			transform.Translate(Vector2.up * Time.deltaTime * 0.5f);
		}
    }
	
	void OnTriggerEnter2D(Collider2D col)
    {
		//print("HIT");
        if(!goup){
			if(col.gameObject.name == "Circle"){
				print("Player Hit!!");
				BossPlayer player = col.gameObject.GetComponent<BossPlayer>();
				player.health -= damage;
			}
		}else{
			if(col.gameObject.name == "Professor"){
				print("Professor Hit!!");
				Boss boss = col.gameObject.GetComponent<Boss>();
				boss.health -= damage;
			}
		}
    }
}
