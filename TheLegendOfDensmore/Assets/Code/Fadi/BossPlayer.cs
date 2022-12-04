using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPlayer : MonoBehaviour
{
	public int health = 20;
	float player_speed = 1;
	public GameObject plasma;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if(health <= 0){
			Destroy(gameObject);
		}
		if(Input.GetKeyDown(KeyCode.Space)){
			Instantiate(plasma, transform.position, Quaternion.identity);
		}
		
		if(transform.position.x > 0.35 && Input.GetAxis("Horizontal") > 0f){
		}
		else if(transform.position.x < -0.35 && Input.GetAxis("Horizontal") < 0f){
		
		} else{
			transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * player_speed,0,0);
		}
	}
}
