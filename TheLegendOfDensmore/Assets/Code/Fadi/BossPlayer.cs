using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPlayer : MonoBehaviour
{
	AudioSource audioData;
	float player_speed = 1;
	float timer = 0f;
	
	
	
	public int health = 20;
	public GameObject plasma;
	public float plasma_wait = 1.0f;
	public int damage = 1;
	
    // Start is called before the first frame update
    void Start()
    {
        audioData = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
		timer += Time.deltaTime;
		if(health <= 0){
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
	}
}
