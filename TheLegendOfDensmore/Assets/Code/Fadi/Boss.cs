using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
	float Timer = 2f;
	bool isgoingright;
	
	public int health = 10;
	public float time_duration = 2f;
	public float boss_speed = 0.5f;
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
		Timer -= Time.deltaTime;
		if (Timer <= 0f)
		{
		 Instantiate(plasma, transform.position, Quaternion.identity);
		 Timer = time_duration;
		}
		
        if(isgoingright){
			transform.Translate(Vector2.right * Time.deltaTime * boss_speed);
			if(transform.position.x > 0.35){
				isgoingright = false;
			}
		}else{
			transform.Translate(Vector2.left * Time.deltaTime * boss_speed);
			if(transform.position.x < -0.35){
				isgoingright = true;
			}
		}
    }
}
