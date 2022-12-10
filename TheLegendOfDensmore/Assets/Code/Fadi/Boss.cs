using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
	AudioSource audioData;
	float Timer = 2f;
	bool isgoingright;
	
	public int health = 10;
	public float time_duration = 2f;
	public float boss_speed = 0.5f;
	public int damage = 1;
	public GameObject plasma;

	Animator ani;
	
    // Start is called before the first frame update
    void Start()
    {
        audioData = GetComponent<AudioSource>();
		ani = GetComponent<Animator>();
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
		 ani.SetBool("Attacking", true);
		 
		  GameObject new_plasma = Instantiate(plasma, transform.position, Quaternion.identity);
		  new_plasma.GetComponent<Plasma>().damage = damage;
		 
		  Timer = time_duration;
		  audioData.Play();

		}
		else
		{
			ani.SetBool("Attacking", false);
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
