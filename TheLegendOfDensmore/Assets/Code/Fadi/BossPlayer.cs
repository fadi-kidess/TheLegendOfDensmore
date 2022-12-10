using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPlayer : MonoBehaviour
{
	AudioSource audioData;
	float player_speed = 1;
	float timer = 0f;
	
	public int health = 50;
	public GameObject plasma;
	public float plasma_wait = 1.0f;
	public int damage = 1;

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
		ani.SetBool("isWalking", true);

		timer += Time.deltaTime;
		if(health <= 0){
			GameObject win = GameObject.Find("Lose");
			win.GetComponent<Animator>().SetBool("lose",true);
			Destroy(gameObject);
		}
		if(Input.GetKeyDown(KeyCode.Space) && timer > plasma_wait){
			GameObject new_plasma = Instantiate(plasma, transform.position, Quaternion.identity);
		 	new_plasma.GetComponent<Plasma>().damage = damage;
			timer = 0;
			audioData.Play();
		}
		
		

		if(transform.position.x > 0.35 && Input.GetAxis("Horizontal") > 0f){

		}
		else if(transform.position.x < -0.35 && Input.GetAxis("Horizontal") < 0f){
			
		} else{
			
			transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * player_speed,0,0);

		}
		gameObject.GetComponent<PlayerStatus>().player_health = (double)health;

		
	}
}
